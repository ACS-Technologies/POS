using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
   public class Accident
    {
        public int? AccidentId { get; set; }
        public int? EnduranceRatio { get; set; }
        public int? InsuranceCompanies { get; set; }
        public decimal? CustomerRatio { get; set; }
        public decimal? InsuranceRatio { get; set; }
        public decimal? CustomerValue { get; set; }
        public decimal? InsuranceValue { get; set; }
        public decimal? DiscountInsurance { get; set; }
        public int? CustomerId { get; set; }
        public int? RelatedId { get; set; }
        public bool Movment { get; set; }
        
    }
    public class AgreementInfo
    {
        public int CustomerId { get; set; }
        public int AgreementStatusId { get; set; }
        public int AgreementId { get; set; }
    }
}
