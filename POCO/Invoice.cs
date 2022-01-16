using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
  public  class Invoice
    {
        public int InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Tax { get; set; }
        public decimal NetTotal { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public int EnduranceRatio { get; set; }
        public int VATNO { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal TotalDetails { get; set; }
        public decimal Discount { get; set; }
        public decimal InsuranceValue { get; set; }
        public decimal CustomerValue { get; set; }
        public decimal InsuranceRatio { get; set; }
        public decimal CustomerRatio { get; set; }
        public string CustomerPrimaryName { get; set; }
        public string CustomerSecondaryname { get; set; }
        public string CompanySecondaryName { get; set; }
        public string CompanyPrimaryName { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Byte[] Img { get; set; }
    }
}
