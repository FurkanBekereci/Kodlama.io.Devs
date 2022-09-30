using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Constants
{
    public static class KodlamaIoUserConstants
    {
        public static string KodlamaIoUserShouldExistMessage = "Kodlama io user should exist when requested.";

        public static string GithubUrlCanNotBeNullMessage = "Github url can not be empty.";
        public static string UserIdIsInvalidMessage = "User id is invalid.";
        public static string UserByUserIdCanNotBeDuplicatedMessage = "This kodlama io user already has had a github profile";
        
    }
}
