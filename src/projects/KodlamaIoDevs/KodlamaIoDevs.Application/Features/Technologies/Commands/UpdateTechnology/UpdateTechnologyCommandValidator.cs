using FluentValidation;
using KodlamaIoDevs.Application.Features.Technologies.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage(TechnologyConstants.NameCanNotBeEmptyMessage);
        }
    }

    
}
