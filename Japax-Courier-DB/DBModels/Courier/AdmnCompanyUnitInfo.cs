using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class AdmnCompanyUnitInfo
    {
        public AdmnCompanyUnitInfo()
        {
            AdmnUserRole = new HashSet<AdmnUserRole>();
            AdmnUserUnitPermission = new HashSet<AdmnUserUnitPermission>();
        }

        public int UnitCode { get; set; }
        public string UnitName { get; set; }
        public string Address { get; set; }
        public string UnitLocation { get; set; }
        public string CityDist { get; set; }
        public string PostalCode { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string MobileNos { get; set; }
        public string TelephoneNos { get; set; }
        public string Email { get; set; }
        public string OtherNos { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string Notes { get; set; }
        public int EntryUser { get; set; }
        public DateTime EntryDate { get; set; }
        public int CompanyCode { get; set; }

        public virtual AdmnCompanyInfo CompanyCodeNavigation { get; set; }
        public virtual ICollection<AdmnUserRole> AdmnUserRole { get; set; }
        public virtual ICollection<AdmnUserUnitPermission> AdmnUserUnitPermission { get; set; }
    }
}
