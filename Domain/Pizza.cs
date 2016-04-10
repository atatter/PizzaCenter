using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }

        //Pizza kirjeldus
        [ForeignKey(nameof(PizzaDescription))]
        public int PizzaDescriptionId { get; set; }
        public virtual MultiLangString PizzaDescription { get; set; }

        //Pizza tellimuses
        public virtual List<PizzaInOrder> PizzaInOrders { get; set; }

        //List hindu pitsa suuruse järgi
        public virtual List<PizzaPriceBySize> PizzaPriceBySizes { get; set; } 

        //List komponente pitsas
        public virtual List<ComponentInPizza> ComponentInPizzas { get; set; }
    }
}
