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
        public int CachAccountId { get; set; }
        public int SalesAccountId { get; set; }
        public int TaxAccountId { get; set; }
        public int? ExpensesTypeId { get; set; }
        public int? PaymentVoucherId { get; set; }

    }
}
