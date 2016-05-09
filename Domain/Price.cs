using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Price
    {
        public int PriceId { get; set; }
        public int Value { get; set; }

        //Hinnatüüp
        public int PriceTypeId { get; set; }
        public virtual PriceType PriceType { get; set; }

        //Millise pitsa hind
        public int PizzaPriceBySizeId { get; set; }
        public virtual PizzaPriceBySize PizzaPriceBySize { get; set; }

        //Millise lisandi hind
        public int ToppingId { get; set; }
        public virtual Topping Topping { get; set; }

        //Millise lisatoote hind
        public int AdditionalProductId { get; set; }
        public virtual AdditionalProduct AdditionalProduct { get; set; }
    }
}
