using System;
using System.Collections.Generic;
using System.Text;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;

namespace Japax_Courier_DB.DBModels.CommonModels.Response
{
    public class RomDbResponse
    {
        public string Status { get; set; }
        public List<CountryInfo> CountryInfo { get; set; }
        public List<ProvicneInfo> DivisionInfo { get; set; }
        public List<CityDistrictInfo> DistrictInfo { get; set; }
        public List<UpazillaInfo> PSUpazilaInfo { get; set; }
        public List<ZoneInfo> ZoneInfo { get; set; }
        public List<AreaInfo> AreaInfo { get; set; }
        public List<RequestTypeInfo> RequestTypeInfo { get; set; }
        public List<NotificationMsgInfo> NotificationMsgInfo { get; set; }
        public List<ProductTypeInfo> ProductTypeInfo { get; set; }
        public List<DeliverySlotsInfo> DeliverySlotsInfo { get; set; }
        public List<PackageTypeInfo> PackageTypeInfo { get; set; }
        public List<ExtraPackagingTypeInfo> ExtraPackagingTypeInfo { get; set; }
        public List<FeedbackQuestionInfo> FeedbackQuestionInfo { get; set; }
        public List<AtcPointInfo> AtcPointInfo { get; set; }
        public List<PickupAndDeliveryTimeSlotsInfo> PickupAndDeliveryTimeSlotsInfo { get; set; }
        public ErrorModel Error { get; set; }
    }
}
