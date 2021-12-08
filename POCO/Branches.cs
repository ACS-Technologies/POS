using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{

    public class Branches
    {
        public int BranchNumber { get; set; }
        public int Id { get; set; }
        public string BranchPrimaryName { get; set; }
        public string BranchSecondaryName { get; set; }
        public string CityPrimaryName { get; set; }
        public int CountryId { get; set; }
        public int BranchID { get; set; }
        public Byte[] Img { get; set; }
        public string CurrencyPrimaryName { get; set; }
        public string CurrencySecondlyName { get; set; }
        public string CurrencyCode { get; set; }
        public int CurrencyIDH { get; set; }
        public string SmallCurPrimaryName { get; set; }
        public string SmallCurSecondaryName { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public string CountryCode { get; set; }
    }
}
