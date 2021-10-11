using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdPickupAndDeliveryZone
    {
        public JcdPickupAndDeliveryZone()
        {
            JcdPickupAndDeliveryArea = new HashSet<JcdPickupAndDeliveryArea>();
        }

        public byte ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int CityDistrictId { get; set; }
        public byte? ActiveStatus { get; set; }

        public virtual JcdCityDistrict CityDistrict { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryArea> JcdPickupAndDeliveryArea { get; set; }
    }
}
