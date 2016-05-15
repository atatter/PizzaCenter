using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Identity;

namespace Web.Areas.Admin.ViewModels
{
    public class InvoicesCreateEditViewModel
    {
        public Invoice Invoice { get; set; }
        public int PaymentMethodId { get; set; }
        public SelectList PaymentMethods { get; set; }
        //TULEB TAGASI NOT NULLIKS MUUTA
        public int? UserIntId { get; set; }
        public SelectList UserInts { get; set; }
        public int? CouponId { get; set; }
        public SelectList Coupons { get; set; }
        public DateTime Date { get; set; }
        public int PhoneNr { get; set; }

        //Hiljem kustutamisele
        public double SUM { get; set; }

        //Testimine
        public int[] OrderIds { get; set; }
        public int[] ItemIds { get; set; }
        public TheOrder[] Orders { get; set; }

    }

    public class InvoiceOrder
    {
        public int InvoiceOrderId { get; set; }
        public List<OrderedItem> OrderedItems { get; set; }
    }

    public class OrderedItem
    {
        public int OrderedItemId { get; set; }
        public int? PizzaId { get; set; }
        public int? AdditionalProductId { get; set; }
    }

    public class ThePizza : Pizza
    {
        public bool Deleted { get; set; }
    }

    public class TheOrder
    {
        public int Inimesi { get; set; }
        public ThePizza[] Pizzas { get; set; }
        public bool Deleted { get; set; }
    }

}