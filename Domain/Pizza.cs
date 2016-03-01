using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual List<OrderedPizza> OrderedPizzas { get; set; }
    }
}
