using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class HandlingChargeResponseModel
    {
        public string Status { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductType { get; set; }
        public decimal HandlingCharge { get; set; }
        public ErrorModel Error { get; set; }
    }
}
