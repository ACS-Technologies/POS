using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Bank
    {
        public int BankId { get; set; }
        public int BankNumber { get; set; }
        public string BankPrimaryName { get; set; }
        public string BankSecondaryName { get; set; }
        public string BankAccountNumber { get; set; }
        public bool IsActive { get; set; }
        public string Error { get; set; }
        public string Name { get; set; }
    }
}
