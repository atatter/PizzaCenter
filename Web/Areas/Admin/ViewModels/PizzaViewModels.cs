using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class PizzaViewModels
    {        
        public Pizza Pizza { get; set; }
        public string PizzaName { get; set; }
        public int[] ComponentSelectListId { get; set; }
        public MultiSelectList ComponentSelectList { get; set; }
        public List<PizzaSize> PizzaSizesList { get; set; }
        public List<PriceType> PriceTypesList { get; set; }
        public List<Price> Price { get; set; }
        public double?[] ThePrice { get; set; }
        public double[] ThePriceTypeId { get; set; }
        public double[] ThePizzaSizeId { get; set; }

    }

    public class PizzaIndexViewModel
    {
        public List<Pizza> Pizzas { get; set; }
        public List<PizzaSize> PizzaSizes { get; set; }
    }

}