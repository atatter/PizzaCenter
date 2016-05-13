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
        public SelectList PriceTypes { get; set; }
        //public SelectList Components { get; set; }
        public List<Component> Components { get; set; }
        public int[] ComponentIds { get; set; }
    }

}