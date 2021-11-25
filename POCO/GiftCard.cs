using System;

namespace POCO
{
    public class GiftCard
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Card_no { get; set; }
        public decimal Value { get; set; }
        public int? Customer_id { get; set; }
        public decimal Balance { get; set; }
        public DateTime? Expiry { get; set; }
        public int Created_by { get; set; }
        public int Store_id { get; set; }
    }
}
