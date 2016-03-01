using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AdditionalComponent
    {
        public int AdditionalComponentId { get; set; }
        public int OrderedPizzaId { get; set; }
        public virtual OrderedPizza OrderedPizza { get; set; }
        public int ComponentId { get; set; }
        public virtual Component Component { get; set; }
    }
}
