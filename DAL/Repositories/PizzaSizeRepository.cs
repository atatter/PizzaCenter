using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class PizzaSizeRepository : EFRepository<PizzaSize>, IPizzaSizeRepository
    {
        public PizzaSizeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
