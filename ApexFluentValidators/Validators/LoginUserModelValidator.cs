using AngularApex.Data.Data;
using FluentValidation;

namespace ApexFluentValidators.Validators
{
    public class LoginUserModelValidator : AbstractValidator<LoginUserModel>
    {
        public LoginUserModelValidator()
        {
            RuleFor(model => model.Email).NotNull();
            RuleFor(model => model.Email).EmailAddress();
            RuleFor(model => model.Password).NotNull();
        }
    }
}
