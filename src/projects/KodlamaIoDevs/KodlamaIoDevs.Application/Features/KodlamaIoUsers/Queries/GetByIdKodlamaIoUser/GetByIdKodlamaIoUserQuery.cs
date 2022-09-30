using AutoMapper;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Dtos;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Queries.GetByIdKodlamaIoUser
{
    public class GetByIdKodlamaIoUserQuery : IRequest<KodlamaIoUserGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdKodlamaIoUserQueryHandler : IRequestHandler<GetByIdKodlamaIoUserQuery, KodlamaIoUserGetByIdDto>
        {
            private readonly IKodlamaIoUserRepository _kodlamaIoUserRepository;
            private readonly IMapper _mapper;
            private readonly KodlamaIoUserBusinessRules _kodlamaIoUserBusinessRules;

            public GetByIdKodlamaIoUserQueryHandler(IKodlamaIoUserRepository kodlamaIoUserRepository, IMapper mapper, KodlamaIoUserBusinessRules kodlamaIoUserBusinessRules)
            {
                _kodlamaIoUserRepository = kodlamaIoUserRepository;
                _mapper = mapper;
                _kodlamaIoUserBusinessRules = kodlamaIoUserBusinessRules;
            }

            public async Task<KodlamaIoUserGetByIdDto> Handle(GetByIdKodlamaIoUserQuery request, CancellationToken cancellationToken)
            {
                KodlamaIoUser kodlamaIoUser = await _kodlamaIoUserRepository.GetAsync(u => u.Id == request.Id);

                _kodlamaIoUserBusinessRules.KodlamaIoUserShouldExistWhenRequested(kodlamaIoUser);

                KodlamaIoUserGetByIdDto kodlamaIoUserGetByIdDto = _mapper.Map<KodlamaIoUserGetByIdDto>(kodlamaIoUser);

                return kodlamaIoUserGetByIdDto;
            }
        }
    }
}
