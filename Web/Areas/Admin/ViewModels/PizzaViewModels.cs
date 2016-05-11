using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class PizzaViewModels
    {
        public Pizza Pizza { get; set; }
        public MultiLangString MultiLangString { get; set; }
    }
}