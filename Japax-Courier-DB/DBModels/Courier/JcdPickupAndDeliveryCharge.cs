using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdPickupAndDeliveryCharge
    {
        public int ChargeId { get; set; }
        public int CityDistrictId { get; set; }
        public byte PickupPoint { get; set; }
        public byte DeliveryPoint { get; set; }
        public decimal PickupCharge { get; set; }
        public decimal DeliveryCharge { get; set; }
        public byte? ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdCityDistrict CityDistrict { get; set; }
        public virtual AdmnUserInfo User { get; set; }
    }
}
