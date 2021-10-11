using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdDestinationCharge
    {
        public JcdDestinationCharge()
        {
            JcdPickupAndDeliveryRequest = new HashSet<JcdPickupAndDeliveryRequest>();
        }

        public int DestinationId { get; set; }
        public byte DeliverySlotsId { get; set; }
        public byte DestinationType { get; set; }
        public decimal DestinationCharge { get; set; }
        public byte? ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdDeliveryTimeSlots DeliverySlots { get; set; }
        public virtual AdmnUserInfo User { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryRequest> JcdPickupAndDeliveryRequest { get; set; }
    }
}
