using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class VehicleDefinitions //: MainDirectoryPath
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public int ManufacturerId { get; set; }
        public int VehicleModelId { get; set; }
        public int ManufacturingYear { get; set; }
        public string PlateNumber { get; set; }
        public int VehicleClassId { get; set; }
        public int FuleTypeId { get; set; }
        public int TankSize { get; set; }
        public int FuleLevelId { get; set; }
        public int FuleLevel { get; set; }

        public bool Limousine { get; set; }
        public string ChassisNo { get; set; }
        public string EngineSerialNumber { get; set; }
        public int EngineCapacity { get; set; }
        public int NumberOfCylinder { get; set; }
        public int Color { get; set; }
        public int SubColor { get; set; }
        public string path { get; set; }
        public string ImageName { get; set; }
        public int CompanyId { get; set; }
        public decimal CatalogOilChangeMeter { set; get; }
        public int TransmissionTypeId { get; set; }
        public int InsuranceTypeId { get; set; }
        public decimal InsuranceValue { get; set; }
        public decimal TotalPrice { get; set; }
        public string Note { get; set; }
        public decimal DailyRentValue { get; set; }
        public decimal WeeklyRentValue { get; set; }
        public decimal MonthlyRentValue { get; set; }
        public decimal ExtraHourPrice { get; set; }
        public decimal ExtraKiloPrice { get; set; }
        public decimal MinimumDailyRent { get; set; }
        public decimal MinimumWeeklyRent { get; set; }
        public decimal MinimumMonthlyRent { get; set; }
        public decimal MinimumAdditionalHours { get; set; }
        public decimal CurrentMeter { get; set; }
        public decimal OilMeter { get; set; }
        public decimal OriginalOilMeter { get; set; }
        public int VehicleStatusId { get; set; }
        public string LastChangeOil { set; get; }
        public int BranchId { get; set; }
        public int AvailabilityBranch { get; set; }
        public decimal CostCenter { get; set; }
        public decimal FixedAssetAccount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyAt { get; set; }
        public bool Status { get; set; }
        public string YearFrom { get; set; }
        public string YearTo { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public TimeSpan PickupTime { get; set; }
        public TimeSpan ReturnTime { get; set; }
        public int FromWhere { get; set; }
        public int IsFromVeichleScreen { get; set; }
        public decimal SellingPrice { get; set; }
        public bool isForSale { get; set; }
        public bool isSold { get; set; }





        public int IsInquiry { get; set; } // if 1 from ReservationInquery
        public int PeriodFilter { set; get; } // 1 Daily , 2 Weekly , 3 Monthly

        public int? ViewMode { get; set; }
        public int? ReservationVehicle { get; set; }
        public int? ReservationId { get; set; }
        public int TotalDays { get; set; }


        //for search purposes
        public string language { get; set; }


        public int BranchPriceClassId { get; set; }

        public string ColorName { get; set; }

        public decimal DailyDiscountAmount { set; get; }
        public decimal OldDailyRentValue { set; get; }
        public decimal WeeklyDiscountAmount { set; get; }
        public decimal OldWeeklyRentValue { set; get; }
        public decimal MonthlyDiscountAmount { set; get; }
        public decimal OldMonthlyRentValue { set; get; }

    }
}
