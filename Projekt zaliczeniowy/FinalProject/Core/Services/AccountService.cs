using Core.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDTO dto);
    }
    public class AccountService : IAccountService
    {
        private readonly Core.Entities.AppContext _dbContext;
        public AccountService(Core.Entities.AppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void RegisterUser(RegisterUserDTO dto)
        {
            var newUser = new User()
            {
                UEmail = dto.UEmail,
                UFirstName = dto.UFirstName,
                ULastName = dto.ULastName,
                ULogin = dto.ULogin,
                UPassword = dto.UPassword,
                RoleId = dto.Role             
            };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}
