using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class SalesInvoiceSettings
    {
        public string FromAccountNo { get; set; }
        public string ToAccountNo { get; set; }
        public string TaxAccountNo { get; set; }
        public string ExtraCharge { get; set; }
        public string CashAccount { get; set; }
        public string PurchaseAccount { get; set; }
        public string SalesAccount { get; set; }
        public string AccountNoReceivable { get; set; }
        public string AccountNoPayable { get; set; }
        public string ItemSalesAccount { get; set; }
        public string ItemPurchasAccount { get; set; }


        public string ItemReturnSalesAccount { get; set; }
        public string ItemReturnPurchasAccount { get; set; }

        public int FromAccountNoId { get; set; }
        public int ToAccountNoId { get; set; }
        public int TaxAccountNoId { get; set; }
        public int ExtraChargeId { get; set; }
        public int CashAccountId { get; set; }
        public int PurchaseAccountId { get; set; }
        public int SalesAccountId { get; set; }
        public int AccountNoReceivableId { get; set; }
        public int AccountNoPayableId { get; set; }
        public int ItemSalesAccountId { get; set; }
        public int ItemPurchasAccountId { get; set; }
        public int ItemReturnSalesAccountId { get; set; }
        public int ItemReturnPurchasAccountId { get; set; }
        public int CompanyId { get; set; }
        public int Branch { get; set; }

        public string FromAccountNoName { get; set; }
        public string ToAccountNoName { get; set; }
        public string TaxAccountNoName { get; set; }
        public string ExtraChargeName { get; set; }
        public string CashAccountName { get; set; }
        public string PurchaseAccountName { get; set; }
        public string SalesAccountName { get; set; }
        public string AccountNoReceivableName { get; set; }
        public string AccountNoPayableName { get; set; }
        public string ItemSalesAccountName { get; set; }
        public string ItemPurchasAccountName { get; set; }

        public string ItemReturnSalesAccountName { get; set; }
        public string ItemReturnPurchasAccountName { get; set; }

        public bool ShowCostCenter { get; set; }
        public bool ShowUnit { get; set; }
        public bool DiscountType { get; set; }
        public string POSCustomer { get; set; }
    }
}
