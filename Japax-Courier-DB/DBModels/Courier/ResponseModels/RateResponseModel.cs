using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class RateResponseModel
    {
        public string PackageType { get; set; }
        public string PackageDimension { get; set; }
        public string PackageWeight { get; set; }
        public string DeliveryType { get; set; }
        public string DeliverySlot { get; set; }
        public decimal PickupCharge { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal PackageCharge { get; set; }
        public decimal HandlingCharge { get; set; }
        public decimal DestinationCharge { get; set; }
        public decimal PackagingCharge { get; set; }
        public decimal TotalCharge { get; set; }
    }
}
