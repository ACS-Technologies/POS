using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Workshop
    {
        public int Id { get; set; }
        public string PrimaryName { get; set; }
        public string SecondaryName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
        public string GoogleURL { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int ParentId { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public int NumberOfPages { get; set; }
        public string ParentPrimaryName { get; set; }
        public string ParentSecondaryName { get; set; }
        public string ConfirmedPassword { get; set; }
        public bool IsActive { get; set; }
    }
    public class WorkshopLevels
    {
        public Workshop ParentWorkshop { get; set; }
        public List<Workshop> BranchWorkshop { get; set; }
        public List<Workshop> SubBranchWorkshop { get; set; }

    }
}
