using FluentValidation;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Commands.DeleteKodlamaIoUser
{
    public class DeleteKodlamaIoUserCommandValidator : AbstractValidator<DeleteKodlamaIoUserCommand>
    {
        public DeleteKodlamaIoUserCommandValidator()
        {
            RuleFor(r => r.UserId).NotNull().Must(m => m >= 0).WithMessage(KodlamaIoUserConstants.UserIdIsInvalidMessage);
        }
    }
}
