using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class View1
    {
        public decimal HandlingCharge { get; set; }
        public decimal DestinationCharge { get; set; }
        public decimal PickupCharge { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal PackagingCharge { get; set; }
    }
}
