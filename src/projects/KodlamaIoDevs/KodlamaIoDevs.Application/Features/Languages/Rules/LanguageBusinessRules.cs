using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Languages.Constants;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository langugageRepository)
        {
            _languageRepository = langugageRepository;
        }

        public void LanguageShouldExistWhenRequested(Language? language)
        {
            if (language == null) throw new BusinessException(LanguageConstants.LanguageShouldExistWhenRequestedMessage);
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException(LanguageConstants.LanguageNameCanNotBeDuplicatedMessage);
        }

        public void LanguageNameShouldBeDifferentWhenUpdated(Language? language, string name)
        {
            if (language!.Name == name) throw new BusinessException(LanguageConstants.LanguageNameShouldBeDifferentWhenUpdatedMessage);
        }
    }
}
