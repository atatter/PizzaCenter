using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ComponentInPizza
    {
        public ComponentInPizza()
        {
            
        }

        public ComponentInPizza(int pizzaId, int componentId)
        {
            PizzaId = pizzaId;
            ComponentId = componentId;
        }
        public int ComponentInPizzaId { get; set; }
        
        //Pitsa
        public int PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; }

        //Komponent
        public int ComponentId { get; set; }
        public virtual Component Component { get; set; }
    }
}
