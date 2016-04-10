using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(ContactTypeName))]
        public int ContactTypeNameId { get; set; }
        public virtual MultiLangString ContactTypeName { get; set; }

        //Pizza tellimuses
        public virtual List<PizzaInOrder> PizzaInOrders { get; set; }

        //List hindu pitsa suuruse järgi
        public virtual List<PizzaPriceBySize> PizzaPriceBySizes { get; set; } 

        //List komponente pitsas
        public virtual List<ComponentInPizza> ComponentInPizzas { get; set; }
    }
}
