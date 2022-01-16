using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Vouchers
    {
        public int Id { get; set; }
        public decimal TaxValue { get; set; }
        public decimal Amount { get; set; }
        public decimal FinesAmountwithTax { get; set; }
        public decimal DiscountAmountwithTax { get; set; }
        public int FK_BranchId { get; set; }
        public int VoucherNo { get; set; }
        public int FK_AgreementId { get; set; }
        public int VoucherTypId { get; set; }
        public Int64? TranNo { get; set; }
        public Int64? TranTypeNo { get; set; }
        public string Notes { get; set; }
        public string VoucherPrimaryName { get; set; }
        public string BranchPrimaryName { get; set; }
        public string FinesReasonName { get; set; }
        public List<Branches> ColBranches { get; set; }
        public List<Vouchers> ColAgreementId { get; set; }
        public string AgreementNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSecondaryname { get; set; }

        public decimal AmountwithTax { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? FinesReason { get; set; }
        public bool BeforeAgreement { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalTax { get; set; }
        public int AgreementStatusId { get; set; }
        public decimal AllowedDiscount { get; set; }
        public bool TaxIncluded { get; set; }
        public decimal TaxPercentage { get; set; }
        public int? FromWhere { get; set; }
        public List<Vouchers> ColFinesVouchers { get; set; }
        public int? Fk_CustomerId { get; set; }
        public List<CurrencyTable> CurrencyTable { get; set; }
        public int CurrencyID { get; set; }
        public int? OtherPricingId { get; set; }
        public DateTime GregorianDate { get; set; }
        public DateTime hijriDate { get; set; }
        public bool ishijriTran { get; set; }
        public int BranchId { get; set; }
        public int OfferId { get; set; }
        public bool CumulativeWithDiscounts { get; set; }
    }
}
