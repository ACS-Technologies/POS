using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
   public class CustomerInformation
    {
        public Int64 Id { get; set; }
        public string CustomerName { get; set; }
        public string Name { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public Int64 AccountNo { get; set; }
        public Int64 AccountReceivable { get; set; }
        
        public decimal? DiscountPercentage { get; set; } // for insurance customer
        public int? DiscountMethod { get; set; } // 1 before , 2 after
    }
}
