using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PizzaSize
    {
        public int PizzaSizeId { get; set; }

        //Piitsa suuruse nimetus
        [ForeignKey(nameof(PizzaSizeName))]
        public int PizzaSizeNameId { get; set; }
        public virtual MultiLangString PizzaSizeName { get; set; }

        public int Diameter { get; set; }

        //List pitsa_hind_suuruse_järgi
        public virtual List<PizzaPriceBySize> PizzaPriceBySizes { get; set; }

    }
}
