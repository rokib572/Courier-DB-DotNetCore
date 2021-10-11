using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class GiftWrappingChargeResponseModel
    {
        public string Status { get; set; }
        public byte GiftWrappingId { get; set; }
        public string WrappingType { get; set; }
        public decimal WrappingCharge { get; set; }
        public ErrorModel Error { get; set; }
    }
}
