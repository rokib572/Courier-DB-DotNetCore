using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdPackageWithWeightCharge
    {
        public JcdPackageWithWeightCharge()
        {
            JcdProductDetails = new HashSet<JcdProductDetails>();
        }

        public int PackageChargeId { get; set; }
        public string PackageType { get; set; }
        public decimal PackageWidth { get; set; }
        public decimal PackageHeight { get; set; }
        public decimal PackageLength { get; set; }
        public string DimensionUnit { get; set; }
        public decimal PackageWeight { get; set; }
        public string WeightUnit { get; set; }
        public string PackageDetails { get; set; }
        public decimal PackageCharge { get; set; }
        public decimal? ExtraPerDimensionCharge { get; set; }
        public decimal? ExtraPerKgWeightCharge { get; set; }
        public byte? ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual ICollection<JcdProductDetails> JcdProductDetails { get; set; }
    }
}
