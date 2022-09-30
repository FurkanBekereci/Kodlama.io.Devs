using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Technologies.Constants;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public void TechnologyShouldExistWhenRequested(Technology? technology)
        {
            if (technology == null) throw new BusinessException(TechnologyConstants.TechnologyShouldExistWhenRequestedMessage);
        }

        public void TechnologyNameShouldBeDifferentWhenUpdated(Technology? technology, string name)
        {
            if (technology!.Name == name) throw new BusinessException(TechnologyConstants.NameShouldBeDifferentWhenUpdatedMessage);
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException(TechnologyConstants.NameCanNotBeDupplicatedMessage);
        }
    }
}
