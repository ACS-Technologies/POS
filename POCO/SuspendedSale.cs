using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class SuspendedSale
    {
        public SuspendedSale()
        {
            SuspendedItems = new List<SuspendedItem>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Customer_id { get; set; }
        public string Customer_name { get; set; }
        public int Vehicle_id { get; set; }
        public string Vehicle_name { get; set; }
        public decimal Total { get; set; }
        public decimal? Product_discount { get; set; }
        public string Order_discount_id { get; set; }
        public decimal? Order_discount { get; set; }
        public decimal? Total_discount { get; set; }
        public decimal? Product_tax { get; set; }
        public string Order_tax_id { get; set; }
        public decimal Order_tax { get; set; }
        public decimal? Total_tax { get; set; }
        public decimal Grand_total { get; set; }
        public int? Total_items { get; set; }
        public decimal? Total_quantity { get; set; }
        public decimal? Paid { get; set; }
        public int? Created_by { get; set; }
        public int? Updated_by { get; set; }
        public DateTime? Updated_at { get; set; }
        public string Note { get; set; }
        public int Store_id { get; set; }
        public string Hold_ref { get; set; }
        public List<SuspendedItem> SuspendedItems { get; set; }
    }
}
