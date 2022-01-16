using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class InsuranceDiscountCalculation
    {
        public int Id { get; set; }
        public string PrimaryName { get; set; }
        public string SeconderyName { get; set; }
        public string InsuranceCompanyEquation { get; set; }
        public string CustomerEquation { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Name { get; set; }
    }
}
