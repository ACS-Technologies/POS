using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Main
    {

        public Store store { get; set; }
        public Payments Payments { get; set; }        
        public List<Item> Item { get; set; }
        public List<Group> Group { get; set; }
        public List<Category> Category { get; set; }
        public List<SuspendedSale> SuspendedSale { get; set; }
        public List<Sales> Sales { get; set; }
        public List<CustomerInformation> CustomerInformation { get; set; }
        public List<PaymentMethod> PaymentMethod { get; set; }
        public List<TransTypeTable> TransTypeTable { get; set; }
        public List<AccountTable> AccountTable { get; set; }
        public List<User> User { get; set; }
        public List<TaxClassificationTable> TaxClassificationTable { get; set; }
        public string ImageUrl { get; set; }
        public Registers Registers { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int SalesId { get; set; }
        public List<BankBranch> oLBankBranch { get; set; }
        public BankBranch oBankBranch { get; set; }
        public List<WorkshopLevels> Workshops { get; set; }
        public SettingAccounts SettingAccounts { get; set; }
        
    }
}
