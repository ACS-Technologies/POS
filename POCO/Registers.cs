using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Registers
    {
        public int Id { get;set;}
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public decimal Cash_in_hand { get; set; }
        public string Status { get; set; }
        public decimal? Total_cash { get; set; }
        public int? Total_cheques { get; set; }
        public int? Total_cc_slips { get; set; }
        public decimal? Total_cash_submitted { get; set; }
        public int? Total_cheques_submitted { get; set; }
        public int? Total_cc_slips_submitted { get; set; }
        public string Note { get; set; }
        public DateTime? Closed_at { get; set; }
        public string Transfer_opened_bills { get; set; }
        public int? Closed_by { get; set; }
        public int Store_id { get; set; }
    }
}
