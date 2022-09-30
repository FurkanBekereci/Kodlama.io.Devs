using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Languages.Constants
{
    public static class LanguageConstants
    {
        public static string LanguageShouldExistWhenRequestedMessage = "Requested language not exist.";

        public static string LanguageNameCanNotBeDuplicatedMessage = "Language name already exists.";

        public static string LanguageNameShouldBeDifferentWhenUpdatedMessage = "Language name is already same.";

        public static string LanguageNameCanNotBeEmptyMessage = "Language name can not be empty.";

    }
}
