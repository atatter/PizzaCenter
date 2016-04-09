using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ComponentAsTopping
    {
        public int ComponentAsToppingId { get; set; }

        //Lisand
        public int ToppingId { get; set; }
        public virtual Topping Topping { get; set; }
        //Komponent
        public int ComponentId { get; set; }
        public virtual Component Component { get; set; }
    }
}
