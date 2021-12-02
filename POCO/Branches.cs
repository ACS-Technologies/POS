using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Branches
    {
        public int BranchID { get; set; }
        public int BranchNumber { get; set; }
        public string BranchName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ServerDateTime { get; set; }
        public DateTime CreateDateTime_UTC { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDateTime_UTC { get; set; }
        public bool IsActive { get; set; }
        public string BranchPrimaryName { get; set; }
        public string BranchSecondaryName { get; set; }

        public Byte[] Img { get; set; }

    }
}
