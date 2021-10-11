using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdPickupAndDeliveryArea
    {
        public JcdPickupAndDeliveryArea()
        {
            JcdAtcPickupAndDeliveryPoint = new HashSet<JcdAtcPickupAndDeliveryPoint>();
            JcdDeliveryHeroInfoAreaIdPmtNavigation = new HashSet<JcdDeliveryHeroInfo>();
            JcdDeliveryHeroInfoAreaIdPrNavigation = new HashSet<JcdDeliveryHeroInfo>();
            JcdPickupAndDeliveryRequestPickupArea = new HashSet<JcdPickupAndDeliveryRequest>();
            JcdPickupAndDeliveryRequestReceiverArea = new HashSet<JcdPickupAndDeliveryRequest>();
            JcdSenderAddress = new HashSet<JcdSenderAddress>();
        }

        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int PsUpazlaId { get; set; }
        public byte? ZoneId { get; set; }
        public string Polygon { get; set; }
        public byte ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdPsUpazila PsUpazla { get; set; }
        public virtual AdmnUserInfo User { get; set; }
        public virtual JcdPickupAndDeliveryZone Zone { get; set; }
        public virtual ICollection<JcdAtcPickupAndDeliveryPoint> JcdAtcPickupAndDeliveryPoint { get; set; }
        public virtual ICollection<JcdDeliveryHeroInfo> JcdDeliveryHeroInfoAreaIdPmtNavigation { get; set; }
        public virtual ICollection<JcdDeliveryHeroInfo> JcdDeliveryHeroInfoAreaIdPrNavigation { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryRequest> JcdPickupAndDeliveryRequestPickupArea { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryRequest> JcdPickupAndDeliveryRequestReceiverArea { get; set; }
        public virtual ICollection<JcdSenderAddress> JcdSenderAddress { get; set; }
    }
}
