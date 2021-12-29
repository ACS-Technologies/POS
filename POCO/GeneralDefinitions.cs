using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class GeneralDefinitions
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int HighestHoursDelayNotCalculated { get; set; }
        public int HighestHourlyDelayCalculated { get; set; }
        public decimal MaximumKiloForMobility { get; set; } // اقصى حد للكيلو مترات المسموحة
        public decimal ExtraPerKM { get; set; }
        public decimal ExtraPerHour { get; set; }
        public int DefaultVehicleTarget { get; set; }
        public int Month { get; set; }
        public bool CustomerBirthDateInContract { get; set; }
        public bool ExtraHoursForFriday { get; set; }
        public int FridayHours { get; set; }
        public bool OneAccountForEachCustomer { get; set; }
        public int AgeOfCustomerForRental { get; set; }
        public bool DebitDiscount { get; set; }
        public bool ExtensionContractExceedingDebtLimit { get; set; }
        public decimal DebtLimit { get; set; }
        public bool CancelContractAfterDuration { get; set; }
        public int CancellationGracePeriod { get; set; }
        public List<Branches> ColBranches { get; set; }
        public bool RentByDuration { get; set; }
        public bool IsMinimumToOpenContract { get; set; }
        public bool IsMinimumToOpenContractByDays { get; set; }
        public decimal MinimumToOpenContract { get; set; }
        public bool IsByDuration { get; set; } // true >> system calculate duration and determine rental type , false >> rental type determined by user
        public decimal MinimumDeposit { get; set; } // minimum deposti to pay in reservation online
        public bool IsRevenueFor30Days { get; set; } // if true >> revenue is calculated as 30 days
        public int PriceClassId { get; set; }
        public int? TaxClassificationId { get; set; }
        public bool AdditionalHourlyAmount { get; set; }
        public bool OneOpenAgreement { get; set; }
        public bool RamadanTiming { get; set; }
        public int RamadanHours { get; set; }
        public bool LimitReceivingTime { get; set; }
        public TimeSpan? ReceivingTime { get; set; }
        public decimal ExtraDriverAmount { get; set; }
        public bool AllowPercentMinimumToOpenAgreement { get; set; }
        public decimal PercentMinimumToOpenAgreement { get; set; }
        public decimal ChauffeurValue { get; set; }
        public decimal InternationalAuthorizationValue { get; set; }
        public bool ApplyDeductibleTax { get; set; }
        public string Remarks { get; set; }
    }
}
