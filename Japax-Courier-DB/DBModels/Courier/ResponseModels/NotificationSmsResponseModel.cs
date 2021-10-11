using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class NotificationSmsResponseModel
    {
        public string Status { get; set; }
        public List<NotificationSmsInfo> NotificationInfo { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class NotificationSmsInfo
    {
        public int MasterId { get; set; }
        public byte NotificationId { get; set; }
        public string NotificationReason { get; set; }
        public string SendNotification { get; set; }
        public string NotificationTo { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationMessage { get; set; }
        public string SendSms { get; set; }
        public string SendSmsTo { get; set; }
        public string SmsMessage { get; set; }
        public string ActiveStatus { get; set; }
        public int UserId { get; set; }
    }

}
