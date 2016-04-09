using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AdditionalProductInOrder
    {
        public int AdditionalProductInOrderId { get; set; }

        //Lisatoode
        public int AdditionalProductId { get; set; }
        public virtual AdditionalProduct AdditionalProduct { get; set; }

        //Tellimus
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
