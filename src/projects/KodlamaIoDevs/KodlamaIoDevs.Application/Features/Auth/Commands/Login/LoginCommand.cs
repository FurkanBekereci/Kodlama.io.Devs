using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaIoDevs.Application.Features.Auth.Constants;
using KodlamaIoDevs.Application.Features.Users.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AccessToken>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly ITokenHelper _tokenHelper;

            public LoginCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _tokenHelper = tokenHelper;
            }

            public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                string email = request.UserForLoginDto.Email;
                string password = request.UserForLoginDto.Password;

                //Get user
                User? userByEmail = await _userRepository.GetAsync(u => u.Email == email);

                //Rules
                await _userBusinessRules.UserCanNotBeNullWhenRequested(userByEmail);

                //Password verification
                if (!HashingHelper.VerifyPasswordHash(password, userByEmail.PasswordHash, userByEmail.PasswordSalt))
                    throw new BusinessException(AuthConstants.PasswordNotVerifiedMessage);

                //Operation Claims
                var operationClaims = _userRepository.GetClaims(userByEmail);

                //Token
                var token = _tokenHelper.CreateToken(userByEmail, operationClaims);

                return token;
            }
        }
    }
}
