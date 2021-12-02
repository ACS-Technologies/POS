using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class CompanyBranch
    {
        public int BranchID { get; set; }
        public int BranchNumber { get; set; }
        public string BranchPrimaryName { get; set; }
        public string BranchSecondaryName { get; set; }
        public string SmallCurPrimaryName { get; set; }
        public string SmallCurSecondaryName { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime ModifyAt { get; set; }
        public bool IsActive { get; set; }
        public string Host { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public bool Ssl { get; set; }
        public CompanyInfo oCompanyInfo { get; set; }
        public List<CompanyInfo> oLCompany { get; set; }
        public bool IsNumberingAutomatic { get; set; }
        public string CurrencyPrimaryName { get; set; }
        public string CurrencySecondlyName { get; set; }
        public string CurrencyCode { get; set; }
        public int CurrencyIDH { get; set; }
        public int CountryId { get; set; }
        public string ISOCode { get; set; }
        public string CountryCode { get; set; }
        public string TaxNumber { get; set; }
        public string RegistrationNo { get; set; }
        public string SMTPEmail { get; set; }
        public int CompanyCountryId { get; set; }
        public string Name { get; set; }
        public bool DefaultForOnline { get; set; }
    }
}
