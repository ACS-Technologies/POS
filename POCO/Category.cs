using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int CategoryNumber { get; set; }
        public string CategoryPrimaryName { get; set; }
        public string CategorySecondaryName { get; set; }
        public string CategoryName { get; set; }
        public decimal CategoryExtraCharge { get; set; }
        public DateTime? CategoryExtraChargeDate { get; set; }
        public TaxType CategoryTaxType { get; set; }
        public bool CategoryService { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int TaxClassificationNo { get; set; }
        public int GroupId { get; set; }
    }
    public enum TaxType
    {
        Taxable,
        Zerotax,
        Exempttax,
        InverseCalculation
    }
}
