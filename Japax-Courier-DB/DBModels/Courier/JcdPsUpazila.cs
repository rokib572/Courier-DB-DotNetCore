using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdPsUpazila
    {
        public JcdPsUpazila()
        {
            JcdDeliveryHeroInfoPsUpazlaIdPmtNavigation = new HashSet<JcdDeliveryHeroInfo>();
            JcdDeliveryHeroInfoPsUpazlaIdPrNavigation = new HashSet<JcdDeliveryHeroInfo>();
            JcdPickupAndDeliveryArea = new HashSet<JcdPickupAndDeliveryArea>();
        }

        public int PsUpazlaId { get; set; }
        public string PsUpazlaName { get; set; }
        public int CityDistrictId { get; set; }
        public byte UnderCityCorporation { get; set; }
        public byte? ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdCityDistrict CityDistrict { get; set; }
        public virtual AdmnUserInfo User { get; set; }
        public virtual ICollection<JcdDeliveryHeroInfo> JcdDeliveryHeroInfoPsUpazlaIdPmtNavigation { get; set; }
        public virtual ICollection<JcdDeliveryHeroInfo> JcdDeliveryHeroInfoPsUpazlaIdPrNavigation { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryArea> JcdPickupAndDeliveryArea { get; set; }
    }
}
