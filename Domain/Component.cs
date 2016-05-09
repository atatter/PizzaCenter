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
        public string Nimetus { get; set; }

        //List komponente lisandiks
        public virtual List<ComponentAsTopping> ComponentsAsTopping { get; set; }
        //List komponente pizzas
        public virtual List<ComponentInPizza> ComponentInPizzas { get; set; }
    }
}
