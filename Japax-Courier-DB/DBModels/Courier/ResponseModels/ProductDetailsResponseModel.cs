using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class ProductDetailsResponseModel
    {
        public string Status { get; set; }
        public List<ProductDetailsInfo> ProductDetails { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class ProductDetailsInfo
    {
        public long RequestId { get; set; }
        public byte SlNo { get; set; }
        public string ProductCode { get; set; }
        public string ProductType { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public string PackageType { get; set; }
        public decimal PackageWeight { get; set; }
        public string WeightUnit { get; set; }
        public decimal PackageHeight { get; set; }
        public decimal PackageWidth { get; set; }
        public decimal PackageLength { get; set; }
        public string DimensionUnit { get; set; }
        public string PackageDimension { get; set; }
        public int PackageChargeId { get; set; }
        public int ProductTypeId { get; set; }
        public decimal PickupCharge { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal DestinationCharge { get; set; }
        public decimal PackageCharge { get; set; }
        public decimal HandlingCharge { get; set; }
        public byte ExtraPackagingId { get; set; }
        public string ExtraPackagingType { get; set; }
        public decimal ExtraPackagingCharge { get; set; }
        public byte WrappingId { get; set; }
        public decimal WrappingCharge { get; set; }
        public byte InsuranceId { get; set; }
        public decimal InsuranceCharge { get; set; }
        public decimal TotalCharge { get; set; }
    }
}
