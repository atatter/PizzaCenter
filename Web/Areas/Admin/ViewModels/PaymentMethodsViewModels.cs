using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class PaymentMethodsCreateEditViewModel
    {
        public PaymentMethod PaymentMethod { get; set; }
        public string PaymentMethodName { get; set; }
    }
}