using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdCountryInfo
    {
        public JcdCountryInfo()
        {
            JcdProvinceStateDivision = new HashSet<JcdProvinceStateDivision>();
        }

        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string TelephoneCode { get; set; }
        public string Notes { get; set; }
        public int EntryUser { get; set; }
        public byte? ActiveStatus { get; set; }

        public virtual AdmnUserInfo EntryUserNavigation { get; set; }
        public virtual ICollection<JcdProvinceStateDivision> JcdProvinceStateDivision { get; set; }
    }
}
