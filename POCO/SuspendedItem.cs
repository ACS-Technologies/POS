using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class SuspendedItem
    {
        public int Id { get; set; }
        public int Suspend_id { get; set; }
        public int Product_id { get; set; }
        public decimal Quantity { get; set; }
        public decimal Unit_price { get; set; }
        public decimal Net_unit_price { get; set; }
        public string Discount { get; set; }
        public decimal? Item_discount { get; set; }
        public int? Tax { get; set; }
        public decimal? Item_tax { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? Real_unit_price { get; set; }
        public string Product_code { get; set; }
        public string Product_name { get; set; }
        public string Comment { get; set; }
        public int? UnitId { get; set; }
        public int? TaxClassificationNo { get; set; }
        
    }
}
