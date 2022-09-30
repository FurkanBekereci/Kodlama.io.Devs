using Core.Persistence.Repositories;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using KodlamaIoDevs.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Persistence.Repositories
{
    public class KodlamaIoUserRepository : EfRepositoryBase<KodlamaIoUser, BaseDbContext>, IKodlamaIoUserRepository
    {
        public KodlamaIoUserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
