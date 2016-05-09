using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PizzaInOrder
    {
        public int PizzaInOrderId { get; set; }

        //Tellimus
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        //Pizza
        public int PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; }

        //List lisandeid tellimuses
        public virtual List<ToppingInPizzaOrder> ToppingsInPizzaOrder { get; set; }
    }
}
