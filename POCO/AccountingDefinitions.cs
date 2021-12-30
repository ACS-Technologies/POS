using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class AccountingDefinitions
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int PurchasingAccount { get; set; }
        public int CustomerAccount { get; set; }
        public int ProfitsAccount { get; set; }
        public int SupplierAccount { get; set; }
        public int AccountReceivable { get; set; }
        public int ExpenseOfClosingContract { get; set; }
        public int DiscountAccount { get; set; }
        public int ExchangeAccount { get; set; }
        public int DailyDuesAccount { get; set; }
        public int CarsCustomers { get; set; }
        public int ReservationVoucherAccount { get; set; }
        public int CustomerInvoiceAccount { get; set; }
        public int FinesAccount { get; set; }
        public int OldContractsAccount { get; set; }
        public int PaymentMethodAccount { get; set; }
        public int ReservationAccount { get; set; }
        public int CompensationIncomeAccount { get; set; }
        public int TaxAccount { get; set; }
        public int FundAccount { get; set; }
        public int BankExpenseAccount { get; set; }
        public int RevenueRentalAccount { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? DailyDuesVoucherId { get; set; } // سند مستحقات يومية

        public int? DiscountsVoucherId { get; set; } // سند الخصم
        public int? FinesVoucherId { get; set; } // سند الغرمات
        public int RepairsAccount { get; set; } // حساب الاصلاحات
        public int ViolationsAccount { get; set; } // حساب المخالفات
        public int MandateAccount { get; set; } // حساب التفويض
        public int SeparationCounterAccount { get; set; } // حساب فصل العداد
        public int RevenueWorthyAccount { get; set; } // حساب الايؤاد المستحق
        public int ContractInsuranceAccount { get; set; } // تأمينات العقود
        public int? InsuranceVoucherId { get; set; } // سند تأمين مركبة
        public int? RevenueDuesVoucherId { get; set; } // سند إيراد مستحق
        public int? PaymentVoucherId { get; set; } // سند قبض
        public int? RecieptVoucherId { get; set; } // سند صرف
        public int TaxDuesAccount { get; set; } //حساب الضريبة المستحق 
    }
}
