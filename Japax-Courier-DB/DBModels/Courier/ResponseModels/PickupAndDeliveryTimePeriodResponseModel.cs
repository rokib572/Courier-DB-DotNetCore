using Japax_Courier_DB.DBModels.CommonModels;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class PickupAndDeliveryTimePeriodResponseModel
    {
        public string Status { get; set; }
        public List<PickupAndDeliveryTimePeriodInfo> TimePeriodInfo { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class PickupAndDeliveryTimePeriodInfo
    {
        public int TimePeriodId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int RequestBefore { get; set; }
        public string RequestBeforeUm { get; set; }
        public int Status { get; set; }
    }
}
