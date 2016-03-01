using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Component
    {
        public int ComponentId { get; set; }
        public string Name { get; set; }
        public virtual List<PizzaComponent> PizzaComponents { get; set; }
        public virtual List<AdditionalComponent> AdditionalComponents { get; set; }

    }
}
