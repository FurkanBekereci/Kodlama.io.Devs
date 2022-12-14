using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Domain.Entities
{
    public class Language : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Technology> Technologies{ get; set; }

        public Language()
        {

        }

        public Language(int id, string name) : this()
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
