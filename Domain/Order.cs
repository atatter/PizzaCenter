using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public int NrOfPeople { get; set; }

        //List lisatooteid tellimuses
        public virtual List<AdditionalProductInOrder> AdditionalProductInOrders { get; set; }

        //List Pizzasid tellimuses
        public virtual List<PizzaInOrder> PizzaInOrders { get; set; }

        //Arve
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
