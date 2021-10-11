using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdCityDistrict
    {
        public JcdCityDistrict()
        {
            JcdPickupAndDeliveryCharge = new HashSet<JcdPickupAndDeliveryCharge>();
            JcdPickupAndDeliveryZone = new HashSet<JcdPickupAndDeliveryZone>();
            JcdPsUpazila = new HashSet<JcdPsUpazila>();
        }

        public int CityDistrictId { get; set; }
        public string CityDistrictName { get; set; }
        public int ProvinceId { get; set; }
        public byte? ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdProvinceStateDivision Province { get; set; }
        public virtual AdmnUserInfo User { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryCharge> JcdPickupAndDeliveryCharge { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryZone> JcdPickupAndDeliveryZone { get; set; }
        public virtual ICollection<JcdPsUpazila> JcdPsUpazila { get; set; }
    }
}
