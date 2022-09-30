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

namespace KodlamaIoDevs.Application.Features.Users.Queries.GetByEmailUser
{
    public class GetByEmailUserQuery : IRequest<GetByEmailUserDto>
    {
        public string Email { get; set; }

        public class GetByEmailUserQueryHandler : IRequestHandler<GetByEmailUserQuery, GetByEmailUserDto>
        {
            private readonly UserBusinessRules userBusinessRules;
            private readonly IUserRepository userRepository;
            private readonly IMapper mapper;

            public GetByEmailUserQueryHandler(UserBusinessRules userBusinessRules, IUserRepository userRepository, IMapper mapper)
            {
                this.userBusinessRules = userBusinessRules;
                this.userRepository = userRepository;
                this.mapper = mapper;
            }

            public async Task<GetByEmailUserDto> Handle(GetByEmailUserQuery request, CancellationToken cancellationToken)
            {
                User? user = await userRepository.GetAsync(u => u.Email == request.Email);

                await userBusinessRules.UserCanNotBeNullWhenRequested(user);

                GetByEmailUserDto getByEmailUserDto = mapper.Map<GetByEmailUserDto>(user);

                return getByEmailUserDto;
            }
        }
    }
}
