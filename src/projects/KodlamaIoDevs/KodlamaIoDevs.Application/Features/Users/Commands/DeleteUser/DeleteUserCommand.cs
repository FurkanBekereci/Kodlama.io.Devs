using AutoMapper;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.Users.Dtos;
using KodlamaIoDevs.Application.Features.Users.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<DeletedUserDto>
    {
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<DeletedUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(u => u.Id == request.Id);

                _userBusinessRules.UserCanNotBeNullWhenRequested(user);

                User deletedUser = await _userRepository.DeleteAsync(user);

                DeletedUserDto deletedUserDto = _mapper.Map<DeletedUserDto>(deletedUser);

                return deletedUserDto;
            }
        }
    }
}
