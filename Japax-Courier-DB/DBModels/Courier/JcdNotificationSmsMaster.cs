using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdNotificationSmsMaster
    {
        public int Id { get; set; }
        public byte NotificationId { get; set; }
        public byte SendNotification { get; set; }
        public string SendNotificationTo { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationMessage { get; set; }
        public byte SendSms { get; set; }
        public string SendSmsTo { get; set; }
        public string SmsMessage { get; set; }
        public byte ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime SetDate { get; set; }

        public virtual JcdNotificationMessages Notification { get; set; }
        public virtual AdmnUserInfo User { get; set; }
    }
}
