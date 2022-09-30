using FluentValidation;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Commands.CreateKodlamaIoUser
{
    public class CreateKodlamaIoUserCommandValidator : AbstractValidator<CreateKodlamaIoUserCommand>
    {
        public CreateKodlamaIoUserCommandValidator()
        {
            RuleFor(r => r.GithubUrl).NotEmpty().WithMessage(KodlamaIoUserConstants.GithubUrlCanNotBeNullMessage);
            RuleFor(r => r.UserId).NotEmpty().Must(i => i >= 0).WithMessage(KodlamaIoUserConstants.UserIdIsInvalidMessage);
        }
    }
}
