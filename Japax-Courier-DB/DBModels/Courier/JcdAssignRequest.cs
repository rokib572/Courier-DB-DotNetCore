using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdAssignRequest
    {
        public JcdAssignRequest()
        {
            JcdAtcPointWiseInventory = new HashSet<JcdAtcPointWiseInventory>();
            JcdPickupAndDeliveryLog = new HashSet<JcdPickupAndDeliveryLog>();
        }

        public long Id { get; set; }
        public long RequestId { get; set; }
        public long DhId { get; set; }
        public long ManifestId { get; set; }
        public byte AssignFor { get; set; }
        public DateTime? AssignDate { get; set; }
        public int AssignBy { get; set; }
        public byte? AcceptStatus { get; set; }
        public DateTime? AcceptDate { get; set; }
        public DateTime? PickupTime { get; set; }
        public DateTime? DeliveredTime { get; set; }
        public byte? CustomerFeedback { get; set; }
        public int PickupPointId { get; set; }
        public int DropPointId { get; set; }
        public byte? AssignStatus { get; set; }

        public virtual AdmnUserInfo AssignByNavigation { get; set; }
        public virtual JcdNotificationMessages AssignForNavigation { get; set; }
        public virtual JcdAtcPickupAndDeliveryPoint DropPoint { get; set; }
        public virtual JcdManifestInfo Manifest { get; set; }
        public virtual JcdAtcPickupAndDeliveryPoint PickupPoint { get; set; }
        public virtual JcdPickupAndDeliveryRequest Request { get; set; }
        public virtual ICollection<JcdAtcPointWiseInventory> JcdAtcPointWiseInventory { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryLog> JcdPickupAndDeliveryLog { get; set; }
    }
}
