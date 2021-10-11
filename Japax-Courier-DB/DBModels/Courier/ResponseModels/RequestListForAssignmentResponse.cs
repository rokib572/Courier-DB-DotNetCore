using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class RequestListForAssignmentResponse
    {
        public string Status { get; set; }
        public List<RequestListForAssignment> RequestList { get; set; }
        public double TotalPage { get; set; }
        public double CurrentPage { get; set; }
        public bool HasNexPage { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class RequestListForAssignment
    {
        public long RequestId { get; set; }
        public long ManifestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestType { get; set; }
        public string DeliveryType { get; set; }
        public DateTime DeliveryBefore { get; set; }
        public string SenderName { get; set; }
        public string SenderMobile { get; set; }
        public string SenderAddress { get; set; }
        public int PickupPointId { get; set; }
        public string PickupPointName { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMobile { get; set; }
        public string ReceiverAddress { get; set; }
        public int DeliveryPointId { get; set; }
        public string DeliveryPointName { get; set; }
    }
}
