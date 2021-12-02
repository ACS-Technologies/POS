using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
   public class PaymentMethod
    {
        public int MethodId { get; set; }
        public string PrimaryName { get; set; }
        public string SecondaryName { get; set; }
        public Int64 AccountNo { get; set; }
        public double BankPercentage { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime ModifyAt { get; set; }
        public bool IsActive { set; get; }
        public PaymentMethodDetails RefMethodDetails { get; set; }
        public List<PaymentMethod> ColpaymentMethods { get; set; }
        public List<AccountTable> AccountNumbers { get; set; }
        public string AccountName { set; get; }
        public bool IsDeleted { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }


        public bool ChequesNumber { set; get; }

        public bool ChequeBank { set; get; }

        //public DateTime Gregorianbirthdate { get; set; }
        //public DateTime? hijribirthdate { get; set; }
        //public bool ishijri { get; set; }

        public bool RequestDate { set; get; }
        public string Name { get; set; }
    }
}
