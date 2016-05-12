using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PriceType
    {
        public int PriceTypeId { get; set; }

        //Hinnatüübi nimetus
        [ForeignKey(nameof(PriceTypeName))]
        public int PriceTypeNameId { get; set; }
        public virtual MultiLangString PriceTypeName { get; set; }

        //List hindu
        public virtual List<Price> Prices { get; set; }
    }
}
