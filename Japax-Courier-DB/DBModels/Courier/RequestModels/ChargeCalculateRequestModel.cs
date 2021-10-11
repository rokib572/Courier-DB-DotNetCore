using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class ChargeCalculateRequestModel
    {
        public byte RequestTypeId { get; set; }       
        public int PickupOutletId { get; set; }
        public int DropOutletId { get; set; }        
        public int SenderAreaId { get; set; }
        public int ReceiverAreaId { get; set; }
        public List<ProductDetailsRequestModel> ProductDetails { get; set; }
    }

    public class ChargeCalculateRequestModelV2
    {
        public byte RequestTypeId { get; set; }
        public int PickupOutletId { get; set; }
        public int DropOutletId { get; set; }
        public int SenderAreaId { get; set; }
        public int ReceiverAreaId { get; set; }
        public TimeSpan RequestBefore { get; set; }
        public List<ProductDetailsRequestModel> ProductDetails { get; set; }
    }

    public class ProductDetailsRequestModel
    {
        public int PackageChargeId { get; set; }
        public int ProductTypeId { get; set; }
        public decimal PackageLength { get; set; }
        public decimal PackageHeight { get; set; }
        public decimal PackageWidth { get; set; }
        public string PackageDimensionUM { get; set; }
        public decimal PackageWeight { get; set; }
        public string PackageWeightUM { get; set; }
        public byte ExtraPackagingId { get; set; }
        public int GiftWrapId { get; set; }
        public int InsuranceId { get; set; }
    }
}
