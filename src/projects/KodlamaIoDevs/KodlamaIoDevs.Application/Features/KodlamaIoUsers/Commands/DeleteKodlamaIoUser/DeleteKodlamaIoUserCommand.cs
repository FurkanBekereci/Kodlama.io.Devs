using AutoMapper;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Commands.CreateKodlamaIoUser;
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

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Commands.DeleteKodlamaIoUser
{
    public class DeleteKodlamaIoUserCommand : IRequest<DeletedKodlamaIoUserDto>
    {
        public int UserId { get; set; }

        public class DeleteKodlamaIoUserCommandHandler : IRequestHandler<DeleteKodlamaIoUserCommand, DeletedKodlamaIoUserDto>
        {
            private readonly IKodlamaIoUserRepository _kodlamaIoUserRepository;
            private readonly IMapper _mapper;
            private readonly KodlamaIoUserBusinessRules _kodlamaIoUserBusinessRules;

            public DeleteKodlamaIoUserCommandHandler(IKodlamaIoUserRepository kodlamaIoUserRepository, IMapper mapper, KodlamaIoUserBusinessRules kodlamaIoUserBusinessRules)
            {
                _kodlamaIoUserRepository = kodlamaIoUserRepository;
                _mapper = mapper;
                _kodlamaIoUserBusinessRules = kodlamaIoUserBusinessRules;
            }

            public async Task<DeletedKodlamaIoUserDto> Handle(DeleteKodlamaIoUserCommand request, CancellationToken cancellationToken)
            {
                KodlamaIoUser kodlamaIoUser = await _kodlamaIoUserRepository.GetAsync(u => u.UserId == request.UserId);

                _kodlamaIoUserBusinessRules.KodlamaIoUserShouldExistWhenRequested(kodlamaIoUser);

                KodlamaIoUser deletedKodlamaIoUser = await _kodlamaIoUserRepository.DeleteAsync(kodlamaIoUser);

                DeletedKodlamaIoUserDto deletedKodlamaIoUserDto = _mapper.Map<DeletedKodlamaIoUserDto>(deletedKodlamaIoUser);

                return deletedKodlamaIoUserDto;
            }
        }
    }
}
