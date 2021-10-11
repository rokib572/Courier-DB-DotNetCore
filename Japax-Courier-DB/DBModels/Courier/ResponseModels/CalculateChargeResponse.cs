using Japax_Courier_DB.DBModels.CommonModels.Response;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class CalculateChargeResponse
    {
        public string Status { get; set; }
        public List<CalculateChargeDetails> ChargeDetails { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class CalculateChargeResponseV2
    {
        public string Status { get; set; }
        public List<CalculateChargeDetailsV2> ChargeDetails { get; set; }
        public ErrorModel Error { get; set; }
    }
    public class CalculateChargeDetailsV2
    {
        public string DeliveryType { get; set; }
        public string DeliverySlot { get; set; }
        public int DestinationId { get; set; }
        public string Disclaimer { get; set; }
        public int DeliveryTime { get; set; }
        public decimal PickupCharge { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal DestinationCharge { get; set; }
        public int PackageChargeId { get; set; }
        public decimal PackageCharge { get; set; }
        public decimal HandlingCharge { get; set; }
        public decimal ExtraPackagingCharge { get; set; }

        [JsonProperty("WrappingCharge")]
        public decimal GiftWrappingCharge { get; set; }
        public decimal InsuranceCharge { get; set; }
        public decimal TotalCharge { get; set; }
    }
    public class CalculateChargeDetails
    {        
        public string DeliveryType { get; set; }
        public string DeliverySlot { get; set; }
        public int DestinationId { get; set; }
        public string Disclaimer { get; set; }
        public decimal PickupCharge { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal DestinationCharge { get; set; }
        public int PackageChargeId { get; set; }
        public decimal PackageCharge { get; set; }
        public decimal HandlingCharge { get; set; }
        public decimal ExtraPackagingCharge { get; set; }

        [JsonProperty("WrappingCharge")]
        public decimal GiftWrappingCharge { get; set; }
        public decimal InsuranceCharge { get; set; }
        public decimal TotalCharge { get; set; }
    }

    [ComplexType]
    public class PackageChargeDetails
    {
        public string DeliveryType { get; set; }
        public string Disclaimer { get; set; }
        public string DeliverySlot { get; set; }
        public decimal PackageCharge { get; set; }
        public decimal HandlingCharge { get; set; }
        public decimal ExtraPackagingCharge { get; set; }

        [JsonProperty("WrappingCharge")]
        public decimal GiftWrappingCharge { get; set; }
        public decimal InsuranceCharge { get; set; }
    }
    public class PacakgeChargeJson
    {
        public string PacakgeDetails { get; set; }
    }
}
