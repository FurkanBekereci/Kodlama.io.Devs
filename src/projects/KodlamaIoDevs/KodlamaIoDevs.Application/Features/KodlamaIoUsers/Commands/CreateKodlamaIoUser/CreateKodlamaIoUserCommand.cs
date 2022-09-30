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

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Commands.CreateKodlamaIoUser
{
    public class CreateKodlamaIoUserCommand : IRequest<CreatedKodlamaIoUserDto>
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }

        public class CreateKodlamaIoUserCommandHandler : IRequestHandler<CreateKodlamaIoUserCommand, CreatedKodlamaIoUserDto>
        {
            private readonly IKodlamaIoUserRepository _kodlamaIoUserRepository;
            private readonly IMapper _mapper;
            private readonly KodlamaIoUserBusinessRules _kodlamaIoUserBusinessRules;

            public CreateKodlamaIoUserCommandHandler(IKodlamaIoUserRepository kodlamaIoUserRepository, IMapper mapper, KodlamaIoUserBusinessRules kodlamaIoUserBusinessRules)
            {
                _kodlamaIoUserRepository = kodlamaIoUserRepository;
                _mapper = mapper;
                _kodlamaIoUserBusinessRules = kodlamaIoUserBusinessRules;
            }

            public async Task<CreatedKodlamaIoUserDto> Handle(CreateKodlamaIoUserCommand request, CancellationToken cancellationToken)
            {
                KodlamaIoUser kodlamaIoUser = _mapper.Map<KodlamaIoUser>(request);

                await _kodlamaIoUserBusinessRules.KodlamaIoUserByUserIdCanNotBeDuplicated(kodlamaIoUser.UserId);

                KodlamaIoUser createdKodlamaIoUser = await _kodlamaIoUserRepository.AddAsync(kodlamaIoUser);

                CreatedKodlamaIoUserDto createdKodlamaIoUserDto = _mapper.Map<CreatedKodlamaIoUserDto>(createdKodlamaIoUser);

                return createdKodlamaIoUserDto;
            }
        }
    }
}
