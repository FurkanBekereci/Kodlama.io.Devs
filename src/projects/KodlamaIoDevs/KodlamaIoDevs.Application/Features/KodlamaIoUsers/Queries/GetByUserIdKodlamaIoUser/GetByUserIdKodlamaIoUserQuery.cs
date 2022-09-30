using AutoMapper;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Dtos;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Queries.GetByUserIdKodlamaIoUser
{
    public class GetByUserIdKodlamaIoUserQuery : IRequest<KodlamaIoUserGetByUserIdDto>
    {
        public int UserId { get; set; }

        public class GetByUserIdKodlamaIoUserQueryHandler : IRequestHandler<GetByUserIdKodlamaIoUserQuery, KodlamaIoUserGetByUserIdDto>
        {
            private readonly IKodlamaIoUserRepository _kodlamaIoUserRepository;
            private readonly IMapper _mapper;
            private readonly KodlamaIoUserBusinessRules _kodlamaIoUserBusinessRules;

            public GetByUserIdKodlamaIoUserQueryHandler(IKodlamaIoUserRepository kodlamaIoUserRepository, IMapper mapper, KodlamaIoUserBusinessRules kodlamaIoUserBusinessRules)
            {
                _kodlamaIoUserRepository = kodlamaIoUserRepository;
                _mapper = mapper;
                _kodlamaIoUserBusinessRules = kodlamaIoUserBusinessRules;
            }

            public async Task<KodlamaIoUserGetByUserIdDto> Handle(GetByUserIdKodlamaIoUserQuery request, CancellationToken cancellationToken)
            {
                KodlamaIoUser kodlamaIoUser = await _kodlamaIoUserRepository.GetAsync(u => u.UserId == request.UserId);

                _kodlamaIoUserBusinessRules.KodlamaIoUserShouldExistWhenRequested(kodlamaIoUser);

                KodlamaIoUserGetByUserIdDto kodlamaIoUserGetByUserIdDto = _mapper.Map<KodlamaIoUserGetByUserIdDto>(kodlamaIoUser);

                return kodlamaIoUserGetByUserIdDto;
            }
        }
    }
}
