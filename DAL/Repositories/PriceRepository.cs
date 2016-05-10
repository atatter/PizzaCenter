using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class PriceRepository : EFRepository<Price>, IPriceRepository
    {
        public PriceRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
