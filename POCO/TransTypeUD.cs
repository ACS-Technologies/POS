using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class TransTypeUD
    {
        public Int64 TranNo { get; set; }
        public Int64 TranTypeNo { get; set; }
        public string AccountNo { get; set; }
        public DateTime TranDate { get; set; }
        public decimal DAmount { get; set; }
        public decimal CAmount { get; set; }
        public string Notes { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserName { get; set; }
        public Int64 CostsCentersNo { get; set; }
        public string HeaderNotes { get; set; }
        public int CurrencyID { get; set; }
    }

    public class Transactions
    {

        public List<POCO.TransTypeUD> oLTransTypeUD { get; set; }
        public List<POCO.ReceiptChequeUD> oLReceiptChequeUD { get; set; }
        public int VoucherType { get; set; }
        public int UserID { get; set; }


        public int CompanyId { get; set; }


        public int BranchId { get; set; }


    }
}
