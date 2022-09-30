using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Auth.Constants
{
    public static class AuthConstants
    {
        public static string FirstNameIsRequiredMessage = "First name can not be empty";
        public static string LastNameIsRequiredMessage = "Last name can not be empty";
        public static string EmailIsRequiredMessage = "Email can not be empty";
        public static string EmailMustMatchPatternMessage = "Email does not match the pattern";
        public static string PasswordIsRequiredMessage = "Password can not be empty";
        public static string PasswordMustHaveMinimumThreeLengthMessage = "Password length must be larger than or equal 3";
        public static string PasswordNotVerifiedMessage = "Password does not match with of this user.";
    }
}
