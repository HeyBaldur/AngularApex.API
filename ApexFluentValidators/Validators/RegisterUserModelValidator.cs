using AngularApex.Data.Models;
using FluentValidation;

namespace ApexFluentValidators.Validators
{
    public class RegisterUserModelValidator : AbstractValidator<RegisterUserModelRequest>
    {
        public RegisterUserModelValidator()
        {
            RuleFor(model => model.Email).NotNull();
            RuleFor(model => model.Email).EmailAddress();
            RuleFor(model => model.Password).NotNull();
            RuleFor(model => model.FullName).NotNull();
        }
    }
}
