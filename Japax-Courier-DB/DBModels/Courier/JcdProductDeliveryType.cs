using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdProductDeliveryType
    {
        public JcdProductDeliveryType()
        {
            JcdPickupAndDeliveryCharge = new HashSet<JcdPickupAndDeliveryCharge>();
        }

        public byte DeliveryTypeId { get; set; }
        public string DeliveryType { get; set; }

        public virtual ICollection<JcdPickupAndDeliveryCharge> JcdPickupAndDeliveryCharge { get; set; }
    }
}
