using Japax_Courier_DB.DBModels.Courier;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.CommonModels
{
    public class PickupDeliveryRequestModel
    {
        public JcdPickupAndDeliveryRequest PickupDelvieryRequest { get; set; }
        public List<JcdProductDetails> ProductDetails { get; set; }
    }
}
