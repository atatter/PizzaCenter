using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ToppingInPizzaOrder
    {
        public int ToppingInPizzaOrderId { get; set; }

        //Lisand
        public int ToppingId { get; set; }
        public virtual Topping Topping { get; set; }

        //Pizza tellimuses
        public int PizzaInOrderId { get; set; }
        public virtual PizzaInOrder PizzaInOrder { get; set; }
    }
}
