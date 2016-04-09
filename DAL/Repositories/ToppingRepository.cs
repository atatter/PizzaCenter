using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class ToppingRepository : EFRepository<Topping>, IToppingRepository
    {
        public ToppingRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
