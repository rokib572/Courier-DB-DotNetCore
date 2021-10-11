using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdProvinceStateDivision
    {
        public JcdProvinceStateDivision()
        {
            JcdCityDistrict = new HashSet<JcdCityDistrict>();
        }

        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CountryId { get; set; }
        public byte ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime SetDate { get; set; }

        public virtual JcdCountryInfo Country { get; set; }
        public virtual ICollection<JcdCityDistrict> JcdCityDistrict { get; set; }
    }
}
