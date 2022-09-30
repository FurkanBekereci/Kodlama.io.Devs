using Core.CrossCuttingConcerns.Exceptions;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Constants;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Rules
{
    public class KodlamaIoUserBusinessRules
    {
        private readonly IKodlamaIoUserRepository _kodlamaIoUserRepository;

        public KodlamaIoUserBusinessRules(IKodlamaIoUserRepository kodlamaIoUserRepository)
        {
            _kodlamaIoUserRepository = kodlamaIoUserRepository;
        }

        public void KodlamaIoUserShouldExistWhenRequested(KodlamaIoUser kodlamaIoUser)
        {
            if (kodlamaIoUser == null) 
                throw new BusinessException(KodlamaIoUserConstants.KodlamaIoUserShouldExistMessage);
        }

        public async Task KodlamaIoUserByUserIdCanNotBeDuplicated(int userId)
        {
            KodlamaIoUser kodlamaIoUser = await _kodlamaIoUserRepository.GetAsync(u => u.UserId == userId);

            if (kodlamaIoUser != null) throw new BusinessException(KodlamaIoUserConstants.UserByUserIdCanNotBeDuplicatedMessage);
        }
    }
}
