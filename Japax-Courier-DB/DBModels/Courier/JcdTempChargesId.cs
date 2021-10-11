using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdTempChargesId
    {
        public byte? SlNo { get; set; }
        public string ProductTypeId { get; set; }
        public int? PackageChargeId { get; set; }
        public decimal? PackageWidth { get; set; }
        public decimal? PackageHeight { get; set; }
        public decimal? PackageLength { get; set; }
        public string DimensionUnit { get; set; }
        public decimal? PackageWeight { get; set; }
        public string WeightUnit { get; set; }
        public decimal? PackageCharge { get; set; }
        public decimal? PickupCharge { get; set; }
        public decimal? DeliveryCharge { get; set; }
        public string ExtraPackagingId { get; set; }
        public string GiftWrappingId { get; set; }
        public byte? DestinationType { get; set; }

        public virtual JcdPackageWithWeightCharge PackageChargeNavigation { get; set; }
    }
}
