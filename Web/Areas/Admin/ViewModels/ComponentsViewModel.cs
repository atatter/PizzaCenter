using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class ComponentsCreateEditViewModel
    {
        public Component Component { get; set; }
        public string ComponentName { get; set; }
    }

}