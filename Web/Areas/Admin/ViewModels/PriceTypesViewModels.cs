using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class PriceTypesCreateEditViewModel
    {
        public PriceType PriceType { get; set; }
        public string PriceTypeName { get; set; }
    }
}