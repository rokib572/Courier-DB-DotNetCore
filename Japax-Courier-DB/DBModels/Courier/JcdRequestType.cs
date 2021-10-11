using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdRequestType
    {
        public JcdRequestType()
        {
            JcdPickupAndDeliveryRequest = new HashSet<JcdPickupAndDeliveryRequest>();
        }

        public byte RequestTypeId { get; set; }
        public string RequestType { get; set; }
        public byte ShowToClient { get; set; }
        public byte ShowToDh { get; set; }
        public byte SysDefine { get; set; }
        public byte? ActiveStatus { get; set; }

        public virtual ICollection<JcdPickupAndDeliveryRequest> JcdPickupAndDeliveryRequest { get; set; }
    }
}
