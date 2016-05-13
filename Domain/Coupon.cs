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
        //Allahindlus %des
        [Range(0, 100)]
        public int Discount { get; set; }
        //Kupongi kood, mille peaks kasutamiseks sisse trükkima
        [MaxLength(64)]
        public string Code { get; set; }
        //Sisu nagu kehtivusaeg, kas ühekordne, kas kasutatud jne
        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        public DateTime EndDate { get; set; }
        public bool IsReusable { get; set; }
        public bool HasBeenUsed { get; set; }

        //List arveid
        public virtual List<Invoice> Invoices { get; set; }
    }
}
