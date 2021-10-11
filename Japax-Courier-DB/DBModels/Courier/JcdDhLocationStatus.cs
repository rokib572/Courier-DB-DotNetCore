using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdDhLocationStatus
    {
        public long LatLongId { get; set; }
        public long RequestId { get; set; }
        public long DhId { get; set; }
        public byte NotificationId { get; set; }
        public DateTime? LatLongTime { get; set; }
        public long AssignId { get; set; }
        public decimal LatitudesData { get; set; }
        public decimal LongitudesData { get; set; }

        public virtual JcdDeliveryHeroInfo Dh { get; set; }
        public virtual JcdPickupAndDeliveryRequest Request { get; set; }
    }
}
