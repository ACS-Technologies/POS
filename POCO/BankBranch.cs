using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class BankBranch
    {
        public int BankBranchId { get; set; }
        public string BranchPrimaryName { get; set; }
        public string BranchSecondaryName { get; set; }
        public string Address { get; set; }
        public int BankId { get; set; }
        public bool IsActive { get; set; }
        public bool IsExchangeable { get; set; }
        public Bank oBank { get; set; }
        public string AccountBankNo { get; set; }
        public List<Bank> oLBank { get; set; }
        public string Name { get; set; }
    }
}
