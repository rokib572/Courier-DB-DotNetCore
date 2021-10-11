using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class PickupAndDeliveryTimePeriodRequestModel
    {
        public int TimePeriodId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int RequestBefore { get; set; }
        public string RequestBeforeUm { get; set; }
        public int Status { get; set; }
    }
}
