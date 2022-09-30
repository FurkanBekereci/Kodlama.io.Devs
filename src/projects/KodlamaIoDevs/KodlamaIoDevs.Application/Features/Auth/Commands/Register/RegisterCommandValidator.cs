using FluentValidation;
using KodlamaIoDevs.Application.Features.Auth.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r => r.UserForRegisterDto.FirstName).NotEmpty().WithMessage(AuthConstants.FirstNameIsRequiredMessage);
            RuleFor(r => r.UserForRegisterDto.LastName).NotEmpty().WithMessage(AuthConstants.LastNameIsRequiredMessage);
            RuleFor(r => r.UserForRegisterDto.Email).NotEmpty().WithMessage(AuthConstants.EmailIsRequiredMessage);
            RuleFor(r => r.UserForRegisterDto.Email).EmailAddress().WithMessage(AuthConstants.EmailMustMatchPatternMessage);
            RuleFor(r => r.UserForRegisterDto.Password).NotEmpty().WithMessage(AuthConstants.PasswordIsRequiredMessage);
            RuleFor(r => r.UserForRegisterDto.Password).MinimumLength(3).WithMessage(AuthConstants.PasswordMustHaveMinimumThreeLengthMessage);
        }
    }
}
