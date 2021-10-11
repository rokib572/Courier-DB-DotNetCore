using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class NotificationMsgModel
    {
        public string Status { get; set; }
        public List<NotificationMsgInfo> NotificationMsgs { get; set; }
        public List<NotificationMesasge> NotificationMessage { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class NotificationMsgInfo
    {
        public int NotificationId { get; set; }
        public string NotificationMsg { get; set; }
        public int ShowToClient { get; set; }
    }

    public class NotificationMesasge
    {
        public byte NotificationId { get; set; }
        public string NotificationMessage { get; set; }
        public byte ActiveStatus { get; set; }
        public byte SysDefine { get; set; }
    }
}
