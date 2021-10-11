using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.CommonModels
{
    public class PackageChargeModel
    {
        public int PackageChargeId { get; set; }
        public string PackageType { get; set; }
        public decimal PackageWidth { get; set; }
        public decimal PackageHeight { get; set; }
        public decimal PackageLength { get; set; }
        public decimal Dimensions { get; set; }
        public string DimensionUnit { get; set; }
        public decimal PackageWeight { get; set; }
        public string WeightUnit { get; set; }
        public string PackageDetails { get; set; }
        public decimal PackageCharge { get; set; }
    }
}
