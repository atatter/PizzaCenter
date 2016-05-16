using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Price
    {
        public int PriceId { get; set; }

        [Range(1, 1000000)]
        public double Value { get; set; }
        //Pitsa suurus
        public int? PizzaSizeId { get; set; }
        public virtual PizzaSize PizzaSize { get; set; }

        //Pitsa millega seotud
        public int? PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; }

        //Hinnatüüp
        public int PriceTypeId { get; set; }
        public virtual PriceType PriceType { get; set; }

        //Millise lisatoote hind
        public int? AdditionalProductId { get; set; }
        public virtual AdditionalProduct AdditionalProduct { get; set; }
    }
}
