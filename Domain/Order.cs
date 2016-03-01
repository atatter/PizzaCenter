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
        public string ClientName { get; set; }
        public virtual List<OrderedPizza> OrderedPizzas { get; set; }
    }
}
