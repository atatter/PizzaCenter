using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class OrderedPizzaRepository : EFRepository<OrderedPizza>, IOrderedPizzaRepository
    {
        public OrderedPizzaRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
