using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
  public  class CurrencyTable
    {
        public int CurrencyID { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyPrimaryName { get; set; }
        public string CurrencySecondlyName { get; set; }
        public decimal CurrencyExchengeRete { get; set; }
        public int DCurrencyID { get; set; }
        public int CompanyId { get; set; }
        public int BranchID { get; set; }
        public string Error { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string Name { get; set; }
    }
}
