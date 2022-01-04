using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Task
    {
        public int RelatedId { get; set; }
        public int Type { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; } //
        public DateTime FromDate { get; set; }//
        public DateTime ToDate { get; set; }//
        public int Status { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public string Title { get; set; }// Product name
        public string Description { get; set; }
        public bool IsHold { get; set; } 
    }
}
