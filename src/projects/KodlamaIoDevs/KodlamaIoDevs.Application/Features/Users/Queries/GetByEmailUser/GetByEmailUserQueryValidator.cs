using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Queries.GetByEmailUser
{
    public class GetByEmailUserQueryValidator : AbstractValidator<GetByEmailUserQuery> 
    {
        public GetByEmailUserQueryValidator()
        {
            RuleFor(r => r.Email).NotEmpty();
            RuleFor(r => r.Email).EmailAddress();
        }
    }
}
