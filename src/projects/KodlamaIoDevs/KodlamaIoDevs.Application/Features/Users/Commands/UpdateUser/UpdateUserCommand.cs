using AutoMapper;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.Users.Commands.UpdateUser;
using KodlamaIoDevs.Application.Features.Users.Dtos;
using KodlamaIoDevs.Application.Features.Users.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdatedUserDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(u => u.Id == request.Id);

                _userBusinessRules.UserCanNotBeNullWhenRequested(user);
                _userBusinessRules.UserEmailCanNotBeDuplicatedWhenInsertedOrUpdated(user.Email);

                user.FirstName = request.FirstName ?? user.FirstName;
                user.LastName = request.LastName ?? user.LastName;
                user.Email = request.Email ?? user.Email;
                user.Status = request.Status ?? user.Status;

                User updatedUser = await _userRepository.UpdateAsync(user);

                UpdatedUserDto updatedUserDto = _mapper.Map<UpdatedUserDto>(updatedUser);

                return updatedUserDto;
            }
        }
    }
}
