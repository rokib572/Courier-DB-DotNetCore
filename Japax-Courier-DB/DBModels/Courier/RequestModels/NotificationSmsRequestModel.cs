using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class NotificationSmsRequestModel
    {
        public int MasterId { get; set; }
        public byte NotificationId { get; set; }
        public byte SendNotification { get; set; }
        public string SendNotificationTo { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationMessage { get; set; }
        public byte SendSms { get; set; }
        public string SendSmsTo { get; set; }
        public string SmsMessage { get; set; }
        public byte ActiveStatus { get; set; }
        public byte UserId { get; set; }
    }
}
