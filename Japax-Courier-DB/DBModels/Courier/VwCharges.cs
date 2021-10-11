using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class VwCharges
    {
        public string PackageDimension { get; set; }
        public string PackageWeight { get; set; }
        public int ProductTypeId { get; set; }
        public decimal HandlingCharge { get; set; }
        public int PackageChargeId { get; set; }
        public string PackageType { get; set; }
        public decimal PackageWidth { get; set; }
        public decimal PackageHeight { get; set; }
        public decimal PackageLength { get; set; }
        public string DimensionUnit { get; set; }
        public decimal PackageWeight1 { get; set; }
        public string WeightUnit { get; set; }
        public string PackageDetails { get; set; }
        public decimal? PackageCharge { get; set; }
        public byte ExtraPackagingId { get; set; }
        public string PackagingType { get; set; }
        public decimal PackagingCharge { get; set; }
        public byte GiftWrappingId { get; set; }
        public string WrappingType { get; set; }
        public decimal WrappingCharge { get; set; }
    }
}
