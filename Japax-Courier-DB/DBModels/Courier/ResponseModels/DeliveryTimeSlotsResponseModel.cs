using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class DeliveryTimeSlotsResponseModel
    {
        public string Status { get; set; }
        public List<DeliveryTimeSlotsInfo> DeliveryTimeSlots { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class DeliveryTimeSlotsInfo
    {
        public byte DeliverySlotsId { get; set; }
        public string DeliveryType { get; set; }
        public string Disclaimer { get; set; }
        public int DeliveryTime { get; set; }
        public string RequestBefore { get; set; }
        public int DestinationId { get; set; }
        public string DestinationType { get; set; }
        public decimal DestinationCharge { get; set; }
        public byte ActiveStatus { get; set; }
        public int UserId { get; set; }
    }

    public class DeliveryTimeSlotsRequest
    {
        public byte DeliverySlotsId { get; set; }
        public string DeliveryType { get; set; }
        public string Disclaimer { get; set; }
        public int DeliveryTime { get; set; }
        public string RequestBefore { get; set; }
        public int DestinationId { get; set; }
        public byte DestinationType { get; set; }
        public decimal DestinationCharge { get; set; }
        public byte ActiveStatus { get; set; }
        public int UserId { get; set; }
    }
}
