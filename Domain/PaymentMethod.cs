using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string Name { get; set; }

        //List arveid
        public virtual List<Invoice> Invoices { get; set; }
    }
}
