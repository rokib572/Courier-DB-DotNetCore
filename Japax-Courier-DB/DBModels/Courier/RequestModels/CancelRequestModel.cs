using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class CancelRequestModel
    {
        public string RequestIds { get; set; }
        public string CancelReason { get; set; }
        public byte CancelledBy { get; set; }
        public int CancelledUserId { get; set; }
    }
}
