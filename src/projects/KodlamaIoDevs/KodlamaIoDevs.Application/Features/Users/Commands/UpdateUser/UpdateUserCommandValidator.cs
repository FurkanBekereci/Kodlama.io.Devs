using FluentValidation;
using KodlamaIoDevs.Application.Features.Users.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty().WithMessage(UserConstants.FirstNameIsRequiredMessage);
            RuleFor(r => r.LastName).NotEmpty().WithMessage(UserConstants.LastNameIsRequiredMessage);
            RuleFor(r => r.Email).NotEmpty().WithMessage(UserConstants.EmailIsRequiredMessage);
            RuleFor(r => r.Email).EmailAddress().WithMessage(UserConstants.EmailMustMatchPatternMessage);
        }
    }
}
