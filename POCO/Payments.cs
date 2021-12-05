using System;

namespace POCO
{
	public class Payments
    {
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int? Sale_id { get; set; }
		public int? Customer_id { get; set; }
		public int Created_by { get; set; }
		public int? Updated_by { get; set; }
		public int Store_id { get; set; }
		public string Transaction_id { get; set; }
		public int Paid_by { get; set; }
		public string Cheque_no { get; set; }
		public string Cc_no { get; set; }
		public string Cc_holder { get; set; }
		public string Cc_month { get; set; }
		public string Cc_year { get; set; }
		public string Cc_type { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
		public string Attachment { get; set; }
		public string Note { get; set; }
		public decimal? Pos_balance { get; set; }
		public string Gc_no { get; set; }
		public string Reference { get; set; }
		public DateTime? Updated_at { get; set; }
		public decimal? Pos_paid { get; set; }
        public int? ChequeBanks { get; set; }
        public DateTime? DateCheque { get; set; }
        public string DateTemp { get; set; }
        
    }
}

