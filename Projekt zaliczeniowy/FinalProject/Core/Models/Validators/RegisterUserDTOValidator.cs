using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.Validators
{
    public class RegisterUserDTOValidator : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserDTOValidator(Core.Entities.AppContext dbContext)
        {
            RuleFor(x => x.UEmail)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.UPassword)
                .MinimumLength(8);

            RuleFor(x => x.UPasswordConfirmed)
                .Equal(e => e.UPassword);

            RuleFor(x => x.UEmail)
                .Custom((value, context) =>
                {
                    var emailInUser = dbContext.Users.Any(x => x.UEmail == value);

                    if (emailInUser)
                        context.AddFailure("Email", "Email zajety");
                });
        }
    }
}
