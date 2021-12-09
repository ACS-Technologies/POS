using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class AccountSalesMaster
    {
        public decimal ID { get; set; }
        public decimal AccSalesNo { get; set; }
        public int AccSalesTypeNo { get; set; }
        public int AccSalesBranch { get; set; }
        public DateTime AccSalesDate { get; set; }
        public string Notes { get; set; }
        public decimal Total { get; set; }
        public string CAccountNo { get; set; }
        public string DAccountNo { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPercentage { get; set; }

        public decimal Net { get; set; }
        public decimal Tax { get; set; }
        public decimal Final { get; set; }
        public string Link { get; set; }

        public int CurrencyID { get; set; }
        public decimal TotalExtraCharge { get; set; }
        public decimal PolicyNo { get; set; }
        public decimal PackageNo { get; set; }
        public decimal Weight { get; set; }
        public decimal NoticeNum { get; set; }
        public string Shipper { get; set; }
        public string ShipperLine { get; set; }
        public string Imo { get; set; }
        public DateTime SupplyDate { get; set; }
        public decimal Currency { get; set; }
        public decimal Cash { get; set; }
        public int InvoiceTypeNo { get; set; }
        public int InvoiceType { get; set; }
        public int PaymentType { get; set; }
        public string UserId { get; set; }
        public int PaymentTerms { get; set; }
        public bool Paid { get; set; }
        public int DelegateID { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public AccountTable oAccountTable { get; set; }
        public TransTypeTable oTransTypeTable { get; set; }
        public CurrencyTable oCurrencyTable { get; set; }

        public CompanyBranch oBranchTable { get; set; }
        public List<AccountTable> oLAccountTable { get; set; }
        public List<TransTypeTable> oLTransTypeTable { get; set; }
        public List<CurrencyTable> oLCurrencyTable { get; set; }
        public List<CompanyBranch> oLBranchTable { get; set; }
        public CustomerInformation oCustomerInformation { get; set; }
        public string InvoiceToSave { get; set; }

    }
    public class AccountSales
    {
        public AccountSalesMaster AccountSalesMaster { get; set; }
        public List<AccountSalesDetails> AccountSalesDetails { get; set; }
        public int CompanyId { get; set; }
        public int BranchId  { get; set; }
    }
    }
