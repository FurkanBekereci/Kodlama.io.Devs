using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Domain.Entities
{
    public class Technology : Entity
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public Technology()
        {

        }

        public Technology(int id, string name, int languageId) : this()
        {
            this.Id = id;
            this.Name = name;
            this.LanguageId = languageId;
        }
    }
}
