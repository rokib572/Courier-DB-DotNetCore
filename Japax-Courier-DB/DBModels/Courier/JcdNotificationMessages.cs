using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdNotificationMessages
    {
        public JcdNotificationMessages()
        {
            JcdAssignRequest = new HashSet<JcdAssignRequest>();
            JcdNotificationSmsMaster = new HashSet<JcdNotificationSmsMaster>();
            JcdPickupAndDeliveryLog = new HashSet<JcdPickupAndDeliveryLog>();
        }

        public byte NotificationId { get; set; }
        public string NotificationMsg { get; set; }
        public byte SysDefine { get; set; }
        public byte? ShowToClient { get; set; }
        public byte? ActiveStatus { get; set; }

        public virtual ICollection<JcdAssignRequest> JcdAssignRequest { get; set; }
        public virtual ICollection<JcdNotificationSmsMaster> JcdNotificationSmsMaster { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryLog> JcdPickupAndDeliveryLog { get; set; }
    }
}
