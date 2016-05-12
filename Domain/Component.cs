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
        [ForeignKey(nameof(ComponentName))]
        public int ComponentNameId { get; set; }
        public virtual MultiLangString ComponentName { get; set; }
        public bool IsTopping { get; set; }

        //List komponente pizzas
        public virtual List<ComponentInPizza> ComponentInPizzas { get; set; }
        //List lisandeid_tellimuses
        public virtual List<ToppingInPizzaOrder> ToppingInPizzaOrders { get; set; }
        //List hindu
        public virtual List<Price> Prices { get; set; }
    }
}
