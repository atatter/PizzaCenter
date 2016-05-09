using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PizzaPriceBySize
    {
        public int PizzaPriceBySizeId { get; set; }

        //Pitsa suurus
        public int PizzaSizeId { get; set; }
        public virtual PizzaSize PizzaSize { get; set; }

        //Pitsa millega seotud
        public int PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; }

        //Hind
        public virtual List<Price> Prices { get; set; }

    }
}
