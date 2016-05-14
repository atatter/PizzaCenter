using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime CreationTime { get; set; }
        [Range(0,10000000)]
        public double SumBeforeCoupon { get; set; }
        [Range(0, 10000000)]
        public double SumAfterCoupon { get; set; }
        [Range(0, 1000000000)]
        public int CustomersPhone { get; set; }
        public bool GivenOut { get; set; }

        //List tellimusi
        public virtual List<Order> Orders { get; set; }

        //Sooduskood
        public int? CouponId { get; set; }
        public virtual Coupon Coupon { get; set; }

        //Makseviis
        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }

        //Klient
        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }

        //User
        public int? UserIntId { get; set; }
        public virtual UserInt UserInt { get; set; }
    }
}
