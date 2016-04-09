using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PizzaSize
    {
        public int PizzaSizeId { get; set; }
        public string Suurus { get; set; }
        public int Diameeter { get; set; }

        //List pitsa_hind_suuruse_järgi
        public virtual List<PizzaPriceBySize> PizzaPriceBySizes { get; set; }

    }
}
