using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupPrimaryName { get; set; }
        public string GroupSecondaryName { get; set; }
        public string GroupName { get; set; }

        public int CompanyId { get; set; }
        public int BranchId { get; set; }
    }
}