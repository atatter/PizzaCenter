using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }

        //Maksviisi nimetus
        [ForeignKey(nameof(PaymentMethodName))]
        public int PaymentMethodNameId { get; set; }
        public virtual MultiLangString PaymentMethodName { get; set; }

        //List arveid
        public virtual List<Invoice> Invoices { get; set; }
    }
}
