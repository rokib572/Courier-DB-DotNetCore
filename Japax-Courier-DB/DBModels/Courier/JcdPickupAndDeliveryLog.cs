using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdPickupAndDeliveryLog
    {
        public long LogId { get; set; }
        public long RequestId { get; set; }
        public long DhId { get; set; }
        public byte NotificationId { get; set; }
        public DateTime? NotificationTime { get; set; }
        public long AssignId { get; set; }

        public virtual JcdAssignRequest Assign { get; set; }
        public virtual JcdNotificationMessages Notification { get; set; }
        public virtual JcdPickupAndDeliveryRequest Request { get; set; }
    }
}
