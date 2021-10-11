using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class UpdateAssignStatusRequestModel
    {
        public long RequestId { get; set; }
        public long DhId { get; set; }
        public byte AssignFor { get; set; }
        public int NotificationId { get; set; }
        public int AssignBy { get; set; }
    }
}
