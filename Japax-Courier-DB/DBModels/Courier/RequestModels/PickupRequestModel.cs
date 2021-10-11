using Japax_Courier_DB.DBModels.CommonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class PickupRequestModel
    {
        public RequestModel RequestInfo { get; set; }
        public List<ProductDetails> ProductDetails { get; set; }
        public int AcknowledgeByIn { get; set; }
    }
    public class RequestModel    {
        public long RequestId { get; set; }
        public string TrackingId { get; set; }
        public long SenderId { get; set; }
        public byte RequestTypeId { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? RequestDate { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? PickupBefore { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? DeliveryBefore { get; set; }
        public string SenderMobileNo { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public int AtcPickupPoint { get; set; }
        public int PickupAreaId { get; set; }
        public string PickupAddress1 { get; set; }
        public string PickupAddress2 { get; set; }
        public string PickupHouseOrRoad { get; set; }
        public string PickupStreet { get; set; }
        public string PickupPostalCode { get; set; }
        public string PickupLandMark { get; set; }
        public decimal? SenderLat { get; set; }
        public decimal? SenderLang { get; set; }
        public int AtcDeliveryPoint { get; set; }
        public byte? PGeocodingStatus { get; set; }
        public string ReceiverMobileNo { get; set; }
        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public int ReceiverAreaId { get; set; }
        public string ReceiverAddress1 { get; set; }
        public string ReceiverAddress2 { get; set; }
        public string ReceiverHouseOrRoad { get; set; }
        public string ReceiverStreet { get; set; }
        public string ReceiverPostalCode { get; set; }
        public string ReceiverLandMark { get; set; }
        public decimal? ReceiverLat { get; set; }
        public decimal? ReceiverLong { get; set; }
        public byte? RGeocodingStatus { get; set; }
        public decimal? PickupCharge { get; set; }
        public decimal? DeliveryCharge { get; set; }
        public int DestinationId { get; set; }
        public decimal? DestinationCharge { get; set; }
        public byte ChargeAmountPayBy { get; set; }
        public decimal ChargeAmount { get; set; }
    }
    public class ProductDetails
    {
        public int SlNo { get; set; }
        public long RequestId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public int PackageChargeId { get; set; }
        public decimal? PackageCharge { get; set; }
        public int ProductTypeId { get; set; }
        public decimal? HandlingCharge { get; set; }
        public byte ExtraPackagingId { get; set; }
        public decimal? ExtraPackagingCharge { get; set; }
        public byte GiftWrappingId { get; set; }
        public decimal? WrappingCharge { get; set; }
        public byte? InsuranceId { get; set; }
        public decimal? InsuranceCharge { get; set; }
        public decimal? PackageWidth { get; set; }
        public decimal? PackageHeight { get; set; }
        public decimal? PackageLength { get; set; }
        public string PackageDimensionUM { get; set; }
        public decimal? PackageWeight { get; set; }
        public string PackageWeightUM { get; set; }
    }
}
