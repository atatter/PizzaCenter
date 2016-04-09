using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Coupon
    {
        public int CouponId { get; set; }
        //Sisu nagu kehtivusaeg, kas ühekordne, kas kasutatud jne

        //List arveid
        public virtual List<Invoice> Invoices { get; set; }
    }
}
