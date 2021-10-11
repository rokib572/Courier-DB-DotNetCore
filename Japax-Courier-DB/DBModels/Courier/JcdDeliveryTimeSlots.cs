using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdDeliveryTimeSlots
    {
        public JcdDeliveryTimeSlots()
        {
            JcdDestinationCharge = new HashSet<JcdDestinationCharge>();
        }

        public byte DeliverySlotsId { get; set; }
        public string DeliveryType { get; set; }
        public string Disclaimer { get; set; }
        public int DeliveryTime { get; set; }
        public TimeSpan? RequestBefore { get; set; }
        public byte? ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual AdmnUserInfo User { get; set; }
        public virtual ICollection<JcdDestinationCharge> JcdDestinationCharge { get; set; }
    }
}
