using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class InvoicesCreateEditViewModel
    {
        public Invoice Invoice { get; set; }
        public int PaymentMethodId { get; set; }
        public SelectList PaymentMethods { get; set; }
        //TULEB TAGASI NOT NULLIKS MUUTA
        public int? PersonId { get; set; }
        public SelectList Persons { get; set; }
        public int? CouponId { get; set; }
        public SelectList Coupons { get; set; }
        public DateTime Date { get; set; }
        public int PhoneNr { get; set; }
        //Hiljem kustutamisele
        public double SUM { get; set; }
    }
}