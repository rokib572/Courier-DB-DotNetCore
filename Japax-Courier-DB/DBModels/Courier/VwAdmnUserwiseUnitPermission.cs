using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class VwAdmnUserwiseUnitPermission
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string UserPass { get; set; }
        public string PassHint { get; set; }
        public string Salt { get; set; }
        public int? CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public int? UnitCode { get; set; }
        public string UnitName { get; set; }
        public string Address { get; set; }
        public string UnitLocation { get; set; }
        public string CityDist { get; set; }
        public string PostalCode { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
    }
}
