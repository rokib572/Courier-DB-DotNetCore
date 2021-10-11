using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdMasterDataLastEntryDate
    {
        public byte Id { get; set; }
        public DateTime CountryName { get; set; }
        public DateTime ProvinceDivision { get; set; }
        public DateTime CityDistrict { get; set; }
        public DateTime PsUpazla { get; set; }
        public DateTime ZoneName { get; set; }
        public DateTime PickupAndDeliveryArea { get; set; }
        public DateTime RequestType { get; set; }
        public DateTime NotificationMsg { get; set; }
        public DateTime ProductType { get; set; }
        public DateTime DeliverySlots { get; set; }
        public DateTime PackageType { get; set; }
        public DateTime ExtraPackagingType { get; set; }
        public DateTime FeedbackQuestionware { get; set; }
        public DateTime AtcPickupAndDeliveryPoint { get; set; }
        public DateTime PickupAndDeliveryTimeSlots { get; set; }
    }
}
