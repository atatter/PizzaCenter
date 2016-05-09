using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PriceType
    {
        public int PriceTypeId { get; set; }
        public string Name { get; set; }

        //List hindu
        public virtual List<Price> Prices { get; set; }
    }
}
