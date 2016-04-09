using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime CreationTime { get; set; }
        public int? SumWOCoupon { get; set; }
        public int? Sum { get; set; }
        public string CustomersName { get; set; }

        //List tellimusi
        public virtual List<Order> Orders { get; set; }  

        //Sooduskood
        public int CouponId { get; set; }
        public virtual Coupon Coupon { get; set; }

        //Makseviis
        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }

        //Klient
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
