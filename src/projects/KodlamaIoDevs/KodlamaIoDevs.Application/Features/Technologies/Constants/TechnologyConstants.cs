using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.Technologies.Constants
{
    public static class TechnologyConstants
    {
        public static string TechnologyShouldExistWhenRequestedMessage = "Technology does not exist.";

        public static string NameCanNotBeEmptyMessage = "Technology name can not be empty.";

        public static string NameShouldBeDifferentWhenUpdatedMessage = "Technology name is already same.";

        public static string NameCanNotBeDupplicatedMessage = "Technology name already exists.";
    }
}
