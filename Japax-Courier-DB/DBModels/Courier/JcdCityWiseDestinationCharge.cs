using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdCityWiseDestinationCharge
    {
        public JcdCityWiseDestinationCharge()
        {
            JcdProductDetails = new HashSet<JcdProductDetails>();
        }

        public int DestinationId { get; set; }
        public int CityDistrictId { get; set; }
        public byte DeliverySlotsId { get; set; }
        public byte WithinSameProvince { get; set; }
        public byte WithinSameCityDistrict { get; set; }
        public byte InterCityOrOutsideCity { get; set; }
        public decimal DestinationCharge { get; set; }
        public byte? ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdCityDistrict CityDistrict { get; set; }
        public virtual JcdDeliveryTimeSlots DeliverySlots { get; set; }
        public virtual AdmnUserInfo User { get; set; }
        public virtual ICollection<JcdProductDetails> JcdProductDetails { get; set; }
    }
}
