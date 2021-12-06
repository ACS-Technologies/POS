using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
  public  class AccountTable
    {
        public int ID { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public bool AcceptTrans { get; set; }
        public bool Debit { get; set; }
        public bool Credit { get; set; }
        public bool ProfitandLoss { get; set; }
        public bool Budget { get; set; }
        public decimal StandardValue { get; set; }
        public bool AcceptCostCenter { get; set; }
        public Int64 ParentId { get; set; }
        public string ParentAccountName { get; set; }
        public string AccountSecondaryName { get; set; }

        public decimal DAmount { get; set; }
        public decimal CAmount { get; set; }
        public int AccountOrder { get; set; }
        public decimal Total { get; set; }
        public int AccountLevel { get; set; }

        public AccountDetailsTable RefAccountDetails { get; set; }
        public TransTable RefTrans { get; set; }
        public string AccountNameNo { get; set; }
        public string AccountSecondaryNameNo { get; set; }
    }
}
