using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class UpdateRequestModel
    {
        public long RequestID { get; set; }
        public long TrackingID { get; set; }
        public long IsPickedUp { get; set; }
        public byte IsDelivered { get; set; }
        public byte IsReported { get; set; }
        public byte IsCancelled { get; set; }
        public string CancelReason { get; set; }
        public byte CancelledBy { get; set; }
        public int CancelledAdminId { get; set; }
        public string OperationCode { get; set; }
	}
}
