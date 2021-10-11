using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class VwAllCharges
    {
        public decimal? PickupCharge { get; set; }
        public decimal? DeliveryCharge { get; set; }
        public decimal? HandlingCharge { get; set; }
        public decimal? PackageCharge { get; set; }
        public decimal? PackagingCharge { get; set; }
        public decimal? WrappingCharge { get; set; }
        public int DestinationId { get; set; }
        public string DeliveryType { get; set; }
        public string Disclaimer { get; set; }
        public decimal DestinationCharge { get; set; }
        public string DeliverySlot { get; set; }
        public decimal? TotalCharge { get; set; }
    }
}
