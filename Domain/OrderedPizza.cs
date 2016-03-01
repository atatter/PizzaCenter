using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderedPizza
    {
        public int OrderedPizzaId { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual List<AdditionalComponent> AdditionalComponents { get; set; }
    }
}
