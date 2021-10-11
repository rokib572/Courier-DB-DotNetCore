using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdManifestInfo
    {
        public JcdManifestInfo()
        {
            JcdAssignRequest = new HashSet<JcdAssignRequest>();
            JcdAtcPointWiseInventoryManifestIdInNavigation = new HashSet<JcdAtcPointWiseInventory>();
            JcdAtcPointWiseInventoryManifestIdOutNavigation = new HashSet<JcdAtcPointWiseInventory>();
            JcdManifestDetailsNoNeed = new HashSet<JcdManifestDetailsNoNeed>();
        }

        public long ManifestId { get; set; }
        public int PickupPointId { get; set; }
        public int DropPointId { get; set; }
        public int NoOfRequest { get; set; }
        public string TrackingNo { get; set; }
        public byte? ManifestStatus { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdAtcPickupAndDeliveryPoint DropPoint { get; set; }
        public virtual JcdAtcPickupAndDeliveryPoint PickupPoint { get; set; }
        public virtual AdmnUserInfo User { get; set; }
        public virtual ICollection<JcdAssignRequest> JcdAssignRequest { get; set; }
        public virtual ICollection<JcdAtcPointWiseInventory> JcdAtcPointWiseInventoryManifestIdInNavigation { get; set; }
        public virtual ICollection<JcdAtcPointWiseInventory> JcdAtcPointWiseInventoryManifestIdOutNavigation { get; set; }
        public virtual ICollection<JcdManifestDetailsNoNeed> JcdManifestDetailsNoNeed { get; set; }
    }
}
