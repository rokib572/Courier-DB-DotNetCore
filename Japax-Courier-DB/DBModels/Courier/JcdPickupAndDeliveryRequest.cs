using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdPickupAndDeliveryRequest
    {
        public JcdPickupAndDeliveryRequest()
        {
            JcdAssignRequest = new HashSet<JcdAssignRequest>();
            JcdAtcPointWiseInventory = new HashSet<JcdAtcPointWiseInventory>();
            JcdCustomerComplained = new HashSet<JcdCustomerComplained>();
            JcdDhLocationStatus = new HashSet<JcdDhLocationStatus>();
            JcdFeedbacks = new HashSet<JcdFeedbacks>();
            JcdManifestDetailsNoNeed = new HashSet<JcdManifestDetailsNoNeed>();
            JcdMerchantOrStarUserTran = new HashSet<JcdMerchantOrStarUserTran>();
            JcdPickupAndDeliveryLog = new HashSet<JcdPickupAndDeliveryLog>();
            JcdProductDetails = new HashSet<JcdProductDetails>();
        }

        public long RequestId { get; set; }
        public string TrackingId { get; set; }
        public long SenderId { get; set; }
        public byte RequestTypeId { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? PickupBefore { get; set; }
        public DateTime? DeliveryBefore { get; set; }
        public string SenderMobileNo { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public int PickupAreaId { get; set; }
        public string PickupAddressLine1 { get; set; }
        public string PickupAddressLine2 { get; set; }
        public string PickupHouseOrRoadNo { get; set; }
        public string PickupStreet { get; set; }
        public string PickupPostalCode { get; set; }
        public string PickupLandmark { get; set; }
        public decimal? SenderLatitudesData { get; set; }
        public decimal? SenderLongitudesData { get; set; }
        public byte? PGeocodingStatus { get; set; }
        public int AtcPickupPoint { get; set; }
        public string SenderNotes { get; set; }
        public string ReceiverMobileNo { get; set; }
        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public int ReceiverAreaId { get; set; }
        public string ReceiverAddressLine1 { get; set; }
        public string ReceiverAddressLine2 { get; set; }
        public string ReceiverHouseOrRoadNo { get; set; }
        public string ReceiverStreet { get; set; }
        public string ReceiverPostalCode { get; set; }
        public string ReceiverLandmark { get; set; }
        public decimal? ReceiverLatitudesData { get; set; }
        public decimal? ReceiverLongitudesData { get; set; }
        public byte? RGeocodingStatus { get; set; }
        public int AtcDeliveryPoint { get; set; }
        public byte? ChargeAmountPayby { get; set; }
        public decimal? PickupCharge { get; set; }
        public decimal? DeliveryCharge { get; set; }
        public int DestinationId { get; set; }
        public decimal? DestinationCharge { get; set; }
        public decimal ChargeAmount { get; set; }
        public byte? IsDelivered { get; set; }
        public byte? IsComplained { get; set; }
        public byte? IsCancelled { get; set; }
        public string CancelledReason { get; set; }
        public byte? CancelledBy { get; set; }
        public int? CancelledUserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdAtcPickupAndDeliveryPoint AtcDeliveryPointNavigation { get; set; }
        public virtual JcdAtcPickupAndDeliveryPoint AtcPickupPointNavigation { get; set; }
        public virtual JcdDestinationCharge Destination { get; set; }
        public virtual JcdPickupAndDeliveryArea PickupArea { get; set; }
        public virtual JcdPickupAndDeliveryArea ReceiverArea { get; set; }
        public virtual JcdRequestType RequestType { get; set; }
        public virtual JcdSenderInfo Sender { get; set; }
        public virtual ICollection<JcdAssignRequest> JcdAssignRequest { get; set; }
        public virtual ICollection<JcdAtcPointWiseInventory> JcdAtcPointWiseInventory { get; set; }
        public virtual ICollection<JcdCustomerComplained> JcdCustomerComplained { get; set; }
        public virtual ICollection<JcdDhLocationStatus> JcdDhLocationStatus { get; set; }
        public virtual ICollection<JcdFeedbacks> JcdFeedbacks { get; set; }
        public virtual ICollection<JcdManifestDetailsNoNeed> JcdManifestDetailsNoNeed { get; set; }
        public virtual ICollection<JcdMerchantOrStarUserTran> JcdMerchantOrStarUserTran { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryLog> JcdPickupAndDeliveryLog { get; set; }
        public virtual ICollection<JcdProductDetails> JcdProductDetails { get; set; }
    }
}
