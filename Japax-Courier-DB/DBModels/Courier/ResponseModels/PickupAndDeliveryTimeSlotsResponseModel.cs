using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class PickupAndDeliveryTimeSlotsInfo
    {
        public int TimePeriodId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int RequestBefore { get; set; }
        public string RequestBeforeUM { get; set; }
    }
}
