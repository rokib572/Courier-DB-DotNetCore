using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdAtcPickupAndDeliveryPoint
    {
        public JcdAtcPickupAndDeliveryPoint()
        {
            JcdAssignRequestDropPoint = new HashSet<JcdAssignRequest>();
            JcdAssignRequestPickupPoint = new HashSet<JcdAssignRequest>();
            JcdAtcPointWiseInventory = new HashSet<JcdAtcPointWiseInventory>();
            JcdManifestInfoDropPoint = new HashSet<JcdManifestInfo>();
            JcdManifestInfoPickupPoint = new HashSet<JcdManifestInfo>();
            JcdPickupAndDeliveryRequestAtcDeliveryPointNavigation = new HashSet<JcdPickupAndDeliveryRequest>();
            JcdPickupAndDeliveryRequestAtcPickupPointNavigation = new HashSet<JcdPickupAndDeliveryRequest>();
        }

        public int AtcPointId { get; set; }
        public string AtcPointName { get; set; }
        public byte? AtcPointType { get; set; }
        public int AtcPointAreaId { get; set; }
        public string AtcPointAddress { get; set; }
        public string HouseOrRoadNo { get; set; }
        public string AtcPointStreet { get; set; }
        public string AtcPointPostalCode { get; set; }
        public string AtcPointLandmark { get; set; }
        public decimal? AtcPointLatitudesData { get; set; }
        public decimal? AtcPointLongitudesData { get; set; }
        public byte? AtcPointGeocodingStatus { get; set; }
        public string AtcPointMobileNo { get; set; }
        public byte? ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdPickupAndDeliveryArea AtcPointArea { get; set; }
        public virtual AdmnUserInfo User { get; set; }
        public virtual ICollection<JcdAssignRequest> JcdAssignRequestDropPoint { get; set; }
        public virtual ICollection<JcdAssignRequest> JcdAssignRequestPickupPoint { get; set; }
        public virtual ICollection<JcdAtcPointWiseInventory> JcdAtcPointWiseInventory { get; set; }
        public virtual ICollection<JcdManifestInfo> JcdManifestInfoDropPoint { get; set; }
        public virtual ICollection<JcdManifestInfo> JcdManifestInfoPickupPoint { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryRequest> JcdPickupAndDeliveryRequestAtcDeliveryPointNavigation { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryRequest> JcdPickupAndDeliveryRequestAtcPickupPointNavigation { get; set; }
    }
}
