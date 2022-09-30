using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using KodlamaIoDevs.Application.Features.Users.Constants;
using KodlamaIoDevs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task UserEmailCanNotBeDuplicatedWhenInsertedOrUpdated(string email)
        {
            User? user = await userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException(UserConstants.EmailCanNotBeDuplicatedMessage);
        }
        
        public async Task UserCanNotBeNullWhenRequested(User user)
        {
            if (user == null) throw new BusinessException(UserConstants.UserNotFoundMessage);
        }
    }
}
