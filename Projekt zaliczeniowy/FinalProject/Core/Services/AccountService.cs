using Core.Entities;
using Core.Exceptions;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Data.Entity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDTO dto);
        string GenerateJwt(LoginDTO dto);
    }
    public class AccountService : IAccountService
    {
        private readonly Core.Entities.AppContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(
            Core.Entities.AppContext dbContext, 
            IPasswordHasher<User> passwordHasher,
            AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public void RegisterUser(RegisterUserDTO dto)
        {
            var newUser = new User()
            {
                UEmail = dto.UEmail,
                UFirstName = dto.UFirstName,
                ULastName = dto.ULastName,
                ULogin = dto.ULogin,
                RoleId = dto.Role             
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.UPassword);
            newUser.UPassword = hashedPassword;
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public string GenerateJwt(LoginDTO dto)
        {
            var user = _dbContext.Users
                .Include(x => x.Role)
                .FirstOrDefault(x => x.UEmail == dto.UEmail);


            //if(user is null)
            //{
            //    throw new BadRequestException("Błędny email lub hasło");
            //}
            var result = _passwordHasher.VerifyHashedPassword(user, user.UPassword, dto.UPassword);
            //if(result == PasswordVerificationResult.Failed)
            //{
            //    throw new BadRequestException("Błędny email lub hasło");
            //}
            
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UID.ToString()),
                new Claim(ClaimTypes.Name, $"{user.UFirstName} {user.ULastName}"),
                new Claim(ClaimTypes.Role,  $"{user.Role.RName}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(
                _authenticationSettings.JwtIssuer, 
                _authenticationSettings.JwtIssuer, 
                claims, 
                expires: expires, 
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
