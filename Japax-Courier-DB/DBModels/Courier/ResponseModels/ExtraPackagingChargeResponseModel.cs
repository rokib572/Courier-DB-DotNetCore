using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class ExtraPackagingChargeResponseModel
    {
        public string Status { get; set; }
        public byte ExtraPackagingId { get; set; }
        public string PackagingType { get; set; }
        public decimal PackagingCharge { get; set; }
        public ErrorModel Error { get; set; }
    }
}
