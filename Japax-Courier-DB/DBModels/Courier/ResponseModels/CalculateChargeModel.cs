using System;
using System.Collections.Generic;
using System.Text;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class CalculateChargeModel
    {
        public string Status { get; set; }
        public int ChargeId { get; set; }
        public int PackageChargeId { get; set; }
        public string PackageType { get; set; }
        public string PackageDimension { get; set; }
        public string PackageWeight { get; set; }
        public string DeliveryType { get; set; }
        public string Disclaimer { get; set; }
        public string DeliverySlot { get; set; }
        public decimal PickupCharge { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal PackageCharge { get; set; }
        public decimal HandlingCharge {get; set;}
        public decimal DestinationCharge { get; set; }
        public decimal TotalCharge { get; set; }
        public decimal ExtraPackagingCharge { get; set; }
        public decimal GiftWrapCharge { get; set; }
        public ErrorModel Error { get; set; }
    }
}
