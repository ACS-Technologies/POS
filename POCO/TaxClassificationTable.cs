using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class TaxClassificationTable
    {
        public int TaxClassificationNo { get; set; }
        public string TaxClassificationName { get; set; }
        public string TaxClassificationArabicName { get; set; }
        public decimal TaxRate { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public string Name { get; set; }

    }
}
