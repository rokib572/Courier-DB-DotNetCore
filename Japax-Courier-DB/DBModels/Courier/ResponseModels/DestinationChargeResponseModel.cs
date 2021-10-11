using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class DestinationChargeResponseModel
    {
        public string Status { get; set; }
        public List<DestinationChargeInfo> DestinationChargeInfo { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class DestinationChargeInfo
    {
        public int DestinationId { get; set; }
        public byte DeliverySlotsId { get; set; }
        public byte DestinationType { get; set; }
        public decimal DestinationCharge { get; set; }
    }
}
