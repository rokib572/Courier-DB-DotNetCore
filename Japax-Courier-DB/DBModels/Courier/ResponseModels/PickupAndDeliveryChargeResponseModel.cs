using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class PickupAndDeliveryChargeResponseModel
    {
        public string Status { get; set; }
        public List<PickupAndDeliveryChargeInfo> ChargeList {get; set;}
        public ErrorModel Error { get; set; }
    }

    public class PickupAndDeliveryChargeInfo
    {
        public int ChargeId { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CityDistrictId { get; set; }
        public string CityDistrictName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string PickupPoint { get; set; }
        public string DeliveryPoint { get; set; }
        public decimal PickupCharge { get; set; }
        public decimal DeliveryCharge { get; set; }
        public byte ActiveStatus { get; set; }
        public int UserId { get; set; }
    }
    public class PickupAndDeliveryReqeustInfo
    {
        public int ChargeId { get; set; }
        public int CityDistrictId { get; set; }
        public int PickupPoint { get; set; }
        public int DeliveryPoint { get; set; }
        public decimal PickupCharge { get; set; }
        public decimal DeliveryCharge { get; set; }
        public byte ActiveStatus { get; set; }
        public int UserId { get; set; }
    }
}
