using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Component
    {
        public int ComponentId { get; set; }

        //List nimetuse tõlkeid
        [ForeignKey(nameof(Nimetus))]
        public int NimetusId { get; set; }
        public virtual MultiLangString Nimetus { get; set; }
        //List komponente lisandiks
        public virtual List<ComponentAsTopping> ComponentsAsTopping { get; set; }
        //List komponente pizzas
        public virtual List<ComponentInPizza> ComponentInPizzas { get; set; }
    }
}
