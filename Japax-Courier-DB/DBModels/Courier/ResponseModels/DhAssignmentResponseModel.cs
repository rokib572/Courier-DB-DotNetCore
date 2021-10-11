using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class DhAssignmentResponseModel
    {
        public string Status { get; set; }
        public List<DhAssignmentResponseInfo> AssignmentInfo { get; set; }
        public Pagination Pagination { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class DhAssignmentResponseInfo
    {
        public long DhId { get; set; }
        public long SenderId { get; set; }
        public byte ChargeAmountPayBy { get; set; }
        public long AssignId { get; set; }
        public string AssignFor { get; set; }
        public DateTime AssignDate { get; set; }
        //public long ManifestId { get; set; }
        public long RequestId { get; set; }
        public string TrackingId { get; set; }
        public DateTime RequestDate { get; set; }
        public byte RequestTypeId { get; set; }
        public string RequestType { get; set; }
        public string DeliveryType { get; set; }
        public string Disclaimer { get; set; }
        public DateTime PickupBefore { get; set; }
        public DateTime DeliveryBefore { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderMobile { get; set; }
        public int SenderAreaId { get; set; }
        public string SenderArea { get; set; }
        public string PickupHouseOrRoadNo { get; set; }
        public string PickupStreet { get; set; }
        public string PickupAddressLine1 { get; set; }
        public string PickupLandmark { get; set; }
        public string PickupPostalCode { get; set; }
        public decimal SenderLatitudesData { get; set; }
        public decimal SenderLongitudesData { get; set; }
        public byte PGeocodingStatus { get; set; }
        public string SenderAddress { get; set; }
        public int PickupPointId { get; set; }
        public string PickupPoint { get; set; }
        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverMobile { get; set; }
        public int ReceiverAreaId { get; set; }
        public string ReceiverArea { get; set; }
        public string ReceiverHouseOrRoadNo { get; set; }
        public string ReceiverStreet { get; set; }
        public string ReceiverAddressLine1 { get; set; }
        public string ReceiverLandmark { get; set; }
        public string ReceiverPostalCode { get; set; }
        public string ReceiverAddress { get; set; }
        public int ReceiverDeliveryPointId { get; set; }
        public string ReceiverDeliveryPoint { get; set; }
        public decimal ReceiverLatitudesData { get; set; }
        public decimal ReceiverLongitudesData { get; set; }
        public byte RGeocodingStatus { get; set; }
        public int DropPointId { get; set; }
        public string DropPoint { get; set; }
        public long LastLogId { get; set; }
        public byte LastNotificationId { get; set; }
        public string LastStatus { get; set; }
        public DateTime LastNotificationTime { get; set; }
    }
}
