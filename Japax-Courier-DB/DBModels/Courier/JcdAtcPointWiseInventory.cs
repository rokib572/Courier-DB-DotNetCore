using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdAtcPointWiseInventory
    {
        public long TranId { get; set; }
        public int AtcPointId { get; set; }
        public long AssignId { get; set; }
        public long? RequestId { get; set; }
        public long ManifestIdIn { get; set; }
        public DateTime? InTime { get; set; }
        public int AcknowledgeByIn { get; set; }
        public long ManifestIdOut { get; set; }
        public DateTime? OutTime { get; set; }
        public int AcknowledgeByOut { get; set; }
        public byte? StockStatus { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual AdmnUserInfo AcknowledgeByInNavigation { get; set; }
        public virtual AdmnUserInfo AcknowledgeByOutNavigation { get; set; }
        public virtual JcdAssignRequest Assign { get; set; }
        public virtual JcdAtcPickupAndDeliveryPoint AtcPoint { get; set; }
        public virtual JcdManifestInfo ManifestIdInNavigation { get; set; }
        public virtual JcdManifestInfo ManifestIdOutNavigation { get; set; }
        public virtual JcdPickupAndDeliveryRequest Request { get; set; }
    }
}
