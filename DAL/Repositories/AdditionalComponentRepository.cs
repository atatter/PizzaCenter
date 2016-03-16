using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class AdditionalComponentRepository : EFRepository<AdditionalComponent>, IAdditionalComponentRepository

    {
            public AdditionalComponentRepository(IDbContext dbContext) : base(dbContext)
            {
            }
    }
}
