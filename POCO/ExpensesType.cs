using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class ExpensesType
    {

        public int Id { get; set; }

        public string PrimaryName { get; set; }
        public string SecondaryName { get; set; }
        public Int64 AccountingNo { get; set; }
        public bool DailySupply { get; set; }
        public int? CraetedBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime ModifyAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }

        public int FK_VehicleDefinitionId { get; set; }
        public string expensstype { get; set; }

        public List<AccountTable> AccountNumbers { get; set; }
        public string AccountName { set; get; }

        public int CompanyId { set; get; }
        public int BranchId { set; get; }


    }
}
