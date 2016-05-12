using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class PizzaSizesVM
    {
        public PizzaSize PizzaSize { get; set; }
        public string PizzaSizeName { get; set; }
    }
}