using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class AccountSalesDetails
    {
        public string KeyId { get; set; }
        public decimal ID { get; set; }
        public decimal AccSalesNo { get; set; }
        public int AccSalesTypeNo { get; set; }
        public Int64? ItemNumber { get; set; }
        public int? UnitId { get; set; }
        public decimal? CostsCentersNo { get; set; }
        public string Description { get; set; }
        public string ClientTaxNo { get; set; }
        public string ClientName { get; set; }
        public string Reference { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal? TaxClassificationId { get; set; }
        public decimal TaxValue { get; set; }
        public decimal ExtraCharge { get; set; }
        public decimal Final { get; set; }
        public decimal AccSalesMasterNo { get; set; }
    }
}
