using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class PackageChargeResponseModel
    {
        public string Status { get; set; }
        public byte SlNo { get; set; }
        public int ProductTypeId { get; set; }
        public int PackageChargeId { get; set; }
        public string PackageType { get; set; }
        public decimal PackageWidth { get; set; }
        public decimal PackageHeight { get; set; }
        public decimal PackageLength { get; set; }
        public string DimensionUnit { get; set; }
        public decimal PackageWeight { get; set; }
        public string WeightUnit { get; set; }
        public string PackageDetails { get; set; }
        public decimal HandlingCharge { get; set; }
        public decimal PackageCharge { get; set; }
        public decimal ExtraPackagingCharge { get; set; }
        public decimal GiftWrappingCharge { get; set; }
        public decimal InsuranceCharge { get; set; }
        public ErrorModel Error { get; set; }
    }
}
