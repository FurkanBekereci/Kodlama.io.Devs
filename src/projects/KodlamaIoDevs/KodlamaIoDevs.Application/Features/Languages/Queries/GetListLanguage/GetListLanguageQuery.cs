using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Languages.Models;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQuery : IRequest<LanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, LanguageListModel>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<LanguageListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Language> Languages = await _languageRepository.GetListAsync(
                                                    index: request.PageRequest.Page, 
                                                    size: request.PageRequest.PageSize,
                                                    include: l => l.Include(i => i.Technologies)
                                                    );
                LanguageListModel mappedLanguageListModel = _mapper.Map<LanguageListModel>(Languages);
                return mappedLanguageListModel;

            }
        }
    }
}
