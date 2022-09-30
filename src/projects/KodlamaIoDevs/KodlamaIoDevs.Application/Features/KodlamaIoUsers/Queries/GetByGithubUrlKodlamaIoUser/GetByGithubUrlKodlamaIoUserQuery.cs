using AutoMapper;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Dtos;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Queries.GetByIdKodlamaIoUser;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Queries.GetByGithubUrlKodlamaIoUser
{
    public class GetByGithubUrlKodlamaIoUserQuery : IRequest<KodlamaIoUserGetByIdGithubUrlDto>
    {
        public string GithubUrl { get; set; }

        public class GetByGithubUrlKodlamaIoUserQueryHandler : IRequestHandler<GetByGithubUrlKodlamaIoUserQuery, KodlamaIoUserGetByIdGithubUrlDto>
        {
            private readonly IKodlamaIoUserRepository _kodlamaIoUserRepository;
            private readonly IMapper _mapper;
            private readonly KodlamaIoUserBusinessRules _kodlamaIoUserBusinessRules;

            public GetByGithubUrlKodlamaIoUserQueryHandler(IKodlamaIoUserRepository kodlamaIoUserRepository, IMapper mapper, KodlamaIoUserBusinessRules kodlamaIoUserBusinessRules)
            {
                _kodlamaIoUserRepository = kodlamaIoUserRepository;
                _mapper = mapper;
                _kodlamaIoUserBusinessRules = kodlamaIoUserBusinessRules;
            }

            public async Task<KodlamaIoUserGetByIdGithubUrlDto> Handle(GetByGithubUrlKodlamaIoUserQuery request, CancellationToken cancellationToken)
            {
                KodlamaIoUser kodlamaIoUser = await _kodlamaIoUserRepository.GetAsync(u => u.GithubUrl == request.GithubUrl);

                _kodlamaIoUserBusinessRules.KodlamaIoUserShouldExistWhenRequested(kodlamaIoUser);

                KodlamaIoUserGetByIdGithubUrlDto kodlamaIoUserGetByIdDto = _mapper.Map<KodlamaIoUserGetByIdGithubUrlDto>(kodlamaIoUser);

                return kodlamaIoUserGetByIdDto;
            }
        }
    }
}
