using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdPickupDeliveryTimePeriods
    {
        public int TimePeriodId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int RequestBefore { get; set; }
        public string RequestBeforeUm { get; set; }
        public int Status { get; set; }
    }
}
