using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PizzaComponent
    {
        public int PizzaComponentId { get; set; }
        public int PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; }
        public int ComponentId { get; set; }
        public virtual Component Component { get; set; }
    }
}
