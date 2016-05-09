using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Topping
    {
        public int ToppingId { get; set; }

        //List lisandeid_tellimuses
        public virtual List<ToppingInPizzaOrder> ToppingInPizzaOrders { get; set; }

        //List komponente_lisandiks
        public virtual List<ComponentAsTopping> ComponentAsToppings { get; set; }
    }
}
