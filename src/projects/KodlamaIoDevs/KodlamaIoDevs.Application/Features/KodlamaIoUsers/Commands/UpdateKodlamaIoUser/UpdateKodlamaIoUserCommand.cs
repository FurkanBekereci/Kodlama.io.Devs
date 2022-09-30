using AutoMapper;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Commands.DeleteKodlamaIoUser;
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

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Commands.UpdateKodlamaIoUser
{
    public class UpdateKodlamaIoUserCommand : IRequest<UpdatedKodlamaIoUserDto>
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public class UpdateKodlamaIoUserCommandHandler : IRequestHandler<UpdateKodlamaIoUserCommand, UpdatedKodlamaIoUserDto>
        {
            private readonly IKodlamaIoUserRepository _kodlamaIoUserRepository;
            private readonly IMapper _mapper;
            private readonly KodlamaIoUserBusinessRules _kodlamaIoUserBusinessRules;

            public UpdateKodlamaIoUserCommandHandler(IKodlamaIoUserRepository kodlamaIoUserRepository, IMapper mapper, KodlamaIoUserBusinessRules kodlamaIoUserBusinessRules)
            {
                _kodlamaIoUserRepository = kodlamaIoUserRepository;
                _mapper = mapper;
                _kodlamaIoUserBusinessRules = kodlamaIoUserBusinessRules;
            }

            public async Task<UpdatedKodlamaIoUserDto> Handle(UpdateKodlamaIoUserCommand request, CancellationToken cancellationToken)
            {
                KodlamaIoUser kodlamaIoUser = await _kodlamaIoUserRepository.GetAsync(u => u.UserId == request.UserId);

                _kodlamaIoUserBusinessRules.KodlamaIoUserShouldExistWhenRequested(kodlamaIoUser);
                _kodlamaIoUserBusinessRules.KodlamaIoUserByUserIdCanNotBeDuplicated(kodlamaIoUser.UserId);

                KodlamaIoUser updatedKodlamaIoUser = await _kodlamaIoUserRepository.UpdateAsync(kodlamaIoUser);

                UpdatedKodlamaIoUserDto updatedKodlamaIoUserDto = _mapper.Map<UpdatedKodlamaIoUserDto>(updatedKodlamaIoUser);

                return updatedKodlamaIoUserDto;
            }
        }
    }
}
