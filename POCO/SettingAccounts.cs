using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
  public  class SettingAccounts
    {
        public int ID { get; set; }
        public int BranchId { get; set; }
        public int TransTypeNo { get; set; }
        public int CurrencyId { get; set; }
        public int PaymentMethodId { get; set; }
        public int CachAccountId { get; set; }
        public int SalesAccountId { get; set; }
        public int TaxAccountId { get; set; }
        public string pin_code { get; set; }
        
        public  List<TransTypeTable> TransTypeTable { get; set; }
        public List<CurrencyTable> CurrencyTable { get; set; }
        public List<PaymentMethod> PaymentMethod { get; set; }
        public List<AccountTable> AccountTable { get; set; }
        
    }
}
