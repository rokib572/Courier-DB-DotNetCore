using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class PickupAndDeliveryZoneModel
    {
        public string Status { get; set; }
        public List<ZoneInfo> Zones { get; set; }
        public ZoneInfo Zone { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class ZoneInfo
    {
        public byte ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int CityDistrictId { get; set; }
    }
}
