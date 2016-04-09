using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AdditionalProduct
    {
        public int AdditionalProductId { get; set; }

        //List hindu
        public virtual List<Price> Prices { get; set; }

        //List lisatooteid tellimuses
        public virtual List<AdditionalProductInOrder> AdditionalProductInOrders { get; set; }
    }
}
