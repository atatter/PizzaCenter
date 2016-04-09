using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class InvoiceRepository : EFRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
