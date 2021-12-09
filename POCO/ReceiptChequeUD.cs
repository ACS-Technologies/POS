using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class ReceiptChequeUD
    {
        public Int64 TranNo { get; set; }
        public Int64 TranTypeNo { get; set; }
        public DateTime TranDate { get; set; }
        public int Branch { get; set; }
        public string ReceivedFrom { get; set; }
        public int DelegateID { get; set; }
        public DateTime Date { get; set; }
        public string Indicator { get; set; }
        public decimal Total { get; set; }
        public int IsChash { get; set; }

        public string ChequeNumber { get; set; }
        public DateTime ChequeDate { get; set; }
        public string ChequeBank { get; set; }

        public string DescriptionCode { get; set; }
    }
}
