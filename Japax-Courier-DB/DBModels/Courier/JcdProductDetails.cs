using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdProductDetails
    {
        public byte SlNo { get; set; }
        public long RequestId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public int PackageChargeId { get; set; }
        public decimal? PackageCharge { get; set; }
        public int ProductTypeId { get; set; }
        public decimal? HandlingCharge { get; set; }
        public byte ExtraPackagingId { get; set; }
        public decimal? PackagingCharge { get; set; }
        public byte GiftWrappingId { get; set; }
        public decimal? WrappingCharge { get; set; }
        public byte? InsuranceId { get; set; }
        public decimal? InsuranceCharge { get; set; }
        public decimal? PackageWidth { get; set; }
        public decimal? PackageHeight { get; set; }
        public decimal? PackageLength { get; set; }
        public string DimensionUnit { get; set; }
        public decimal? PackageWeight { get; set; }
        public string WeightUnit { get; set; }

        public virtual JcdAdditionalPackagingCharge ExtraPackaging { get; set; }
        public virtual JcdGiftWrappingCharge GiftWrapping { get; set; }
        public virtual JcdPackageWithWeightCharge PackageChargeNavigation { get; set; }
        public virtual JcdProductType ProductType { get; set; }
        public virtual JcdPickupAndDeliveryRequest Request { get; set; }
    }
}
