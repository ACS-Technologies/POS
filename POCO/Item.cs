using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Item
    {
        public Int64 ItemId { get; set; }
        public int ItemNumber { get; set; }
        public string ItemBarcode { get; set; }
        public string ItemPrimaryName { get; set; }
        public string ItemSecondaryName { get; set; }
        public int CategoryId { get; set; }
        public string ItemPurchaseAccount { get; set; }
        public string ItemSalesAccount { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public string ItemPurchaseAccountId { get; set; }
        public string ItemSalesAccountId { get; set; }
        public bool IsActive { get; set; }
        public decimal taxRate { get; set; }
        public decimal Price { get; set; }
        public bool Service { get; set; }
        public decimal PurchasingPrice { get; set; }
        public decimal ExtraCharge { get; set; }
        public string CategoryPrimaryName { get; set; }
        public string CategorySecondaryName { get; set; }
        public int TaxClassificationNo { get; set; }
        public int UnitId { get; set; }
        public string Image { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string ItemUnitToSave { get; set; }
        public decimal MinQuantity { get; set; }
        public string BarcodeSymbolog { get; set; }
    }
}
