using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaIoDevs.Application.Features.Users.Commands.CreateUser;
using KodlamaIoDevs.Application.Features.Users.Dtos;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<AccessToken>
    {
        public UserForRegisterDto UserForRegisterDto{ get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;

            public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
            }

            public async Task<AccessToken> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                //Bu command bu şekilde kullanılır mı?
                //CreateUserCommand createUserCommand =  new CreateUserCommand();

                var password = request.UserForRegisterDto.Password;

                //Password section
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                //User creating section
                User user = _mapper.Map<User>(request.UserForRegisterDto);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Status = true;

                User createdUser = await _userRepository.AddAsync(user);

                //Operation claims
                var operationClaims = _userRepository.GetClaims(createdUser);

                //Token
                var token = _tokenHelper.CreateToken(createdUser, operationClaims);

                return token;
            }
        }
    }
}
