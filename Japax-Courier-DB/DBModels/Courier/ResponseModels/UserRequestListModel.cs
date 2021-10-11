using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class UserRequestListModel
    {
        public string Status { get; set; }
        public List<UserRequestInfo> RequestInfo { get; set; }
        public double CurrentPage { get; set; }
        public double TotalPage { get; set; }
        public bool HasNexPage { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class UserRequestInfo
    {
        public long RequestId { get; set; }
        public string TrackingId { get; set; }
        public string SenderName { get; set; }
        public string SenderMobile { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMobile { get; set; }
        public string ReceiverAddress { get; set; }
        public string RequestType { get; set; }
        public string RequestStatus { get; set; }
        public DateTime? NotificationTime { get; set; }
    }
    public class GetRequestResult
    {
        public string PickupAndDeliveryRequestInfo { get; set; }
    }
}
