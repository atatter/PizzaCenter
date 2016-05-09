using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Coupon
    {
        public int CouponId { get; set; }
        //Sisu nagu kehtivusaeg, kas ühekordne, kas kasutatud jne
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        public bool IsReusable { get; set; }
        public bool HasBeenUsed { get; set; }

        //List arveid
        public virtual List<Invoice> Invoices { get; set; }
    }
}
