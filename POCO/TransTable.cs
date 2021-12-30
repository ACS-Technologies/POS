using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class TransTable
    {
        public bool? Post { get; set; }
        public bool? Confirmed { get; set; }
        public int ID { get; set; }
        public Int64 TranNo { get; set; }
        public Int64 TranTypeNo { get; set; }
        public Int64? RevenueTransNo { get; set; }
        public Int64? RevenueTransTypeNo { get; set; }
        public bool? IsWorkShop { get; set; }
        public Int64 AccountNo { get; set; }
        public decimal DAmount { get; set; }
        public decimal CAmount { get; set; }
        public DateTime transDate { get; set; }
        public int? Fk_PaymentId { get; set; }
        public int? InvoiceNo { get; set; }
        public decimal? InvoiceTotal { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N3}")]
        public decimal Total { get; set; }
        public string Notes { get; set; }
        public string TranType { get; set; }
        public string AccountName { get; set; }
        public DateTime CreateDate { get; set; }
        //public string UserName { get; set; }
        public Int64 CostsCentersNo { get; set; }

        public int CurrencyID { get; set; }
        public List<CurrencyTable> currencyTables { set; get; }
        public string CurrencyName { set; get; }

        public AccountTable oAccountTable { get; set; }

        // public CentersCostsTable oCentersCostsTable { get; set; }
        public TransTypeTable oTransTypeTable { get; set; }
        public CurrencyTable oCurrencyTable { get; set; }
        public List<AccountTable> oLAccountTable { get; set; }

        // public List<CentersCostsTable> oLCentersCostsTable { get; set; }
        public List<TransTable> oLTransaction { get; set; }
        public List<TransTypeTable> oLTransTypeTable { get; set; }
        public List<CurrencyTable> oLCurrencyTable { get; set; }
        public decimal LessThanOrEqual30 { get; set; }
        public decimal MoreThan30LessThan60 { get; set; }
        public decimal MoreThan60LessThan90 { get; set; }
        public decimal MoreThan90LessThan120 { get; set; }
        public decimal MoreThan120 { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime DueDate { get; set; }
        public int DaysOverDue { get; set; }
        public List<TransTable> oLAccountTableNoParent { get; set; }
        public int? ExpensesType { set; get; }
        public string ExpensesName { set; get; }
        public int? Fk_AgreementId { get; set; }
        public string AgreementNo { get; set; }
        public string ReservationNo { get; set; }
        public int? Fk_ReservationId { get; set; }
        public string Manufacturers { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleClass { get; set; }
        public int VehicleDefinitionsId { get; set; }

        public int? PaymentMethod { set; get; }
        public int PaymentType { set; get; }
        public List<PaymentMethod> paymentMethods { set; get; }
        public string PaymentMethodName { set; get; }

        public int Branch { get; set; }
        public List<Branches> Branches { set; get; }
        public string BranchesName { set; get; }

        public DateTime GregorianTransDate { get; set; }
        public DateTime hijriTransDate { get; set; }
        public bool ishijriTran { get; set; }

        public string Payfor { get; set; }
        public string Indicator { get; set; }
        public string DescriptionCode { get; set; }

        public string ChequeNumber { set; get; }
        public int ChequeBank { set; get; }
        public string ChequeBankName { set; get; }

        public DateTime? GregorianChequebankDate { get; set; }
        public DateTime? hijriChequebankDate { get; set; }
        public bool ishijriChequebank { get; set; }

        public TransTable oTransTable { get; set; }
        public BankBranch oBankBranch { get; set; }
        public CompanyBranch RefCompanyBranch { get; set; }
        public List<TransTable> oLTransTable { get; set; }
        public List<BankBranch> oLBankBranch { get; set; }
        public Bank oBank { get; set; }

        public int CreatedBy { set; get; }

        public int ModifyBy { set; get; }

        public DateTime ModifyAt { set; get; }

        public int CompanyId { set; get; }

        public int VoucherType { set; get; }
        public int? PlateNumber { set; get; }
        public int? Fk_CustomerId { set; get; }

        public string CustomerSecondaryname { set; get; }
        public string CustomerName { set; get; }
        public string PlateNumbers { set; get; }
        public decimal FinalTotal { set; get; }
        public decimal OldTotal { set; get; }
        public bool IsLimousine { set; get; }
        public decimal Tax { set; get; }
    }
}
