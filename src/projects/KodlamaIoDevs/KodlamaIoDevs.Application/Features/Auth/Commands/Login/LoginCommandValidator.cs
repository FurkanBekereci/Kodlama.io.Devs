using FluentValidation;
using KodlamaIoDevs.Application.Features.Auth.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(r => r.UserForLoginDto.Email).NotEmpty().WithMessage(AuthConstants.EmailIsRequiredMessage);
            RuleFor(r => r.UserForLoginDto.Email).EmailAddress().WithMessage(AuthConstants.EmailMustMatchPatternMessage);
            RuleFor(r => r.UserForLoginDto.Password).NotEmpty().WithMessage(AuthConstants.PasswordIsRequiredMessage);
            RuleFor(r => r.UserForLoginDto.Password).MinimumLength(3).WithMessage(AuthConstants.PasswordMustHaveMinimumThreeLengthMessage);
        }
    }
}
