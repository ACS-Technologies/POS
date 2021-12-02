using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
   public class TransTypeTable
    {
        public Int64 ID { get; set; }
        public string TransType { get; set; }
        public string TransTypeArabic { get; set; }
        public bool YearFlage { get; set; }
        public bool MonthFlage { get; set; }
        public int VoucherType { get; set; }
        public string VoucherTypeName { get; set; }
        public bool IsAutoCreated { get; set; }
    }
}
