using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class PackageWithChargeResponseModel
    {
        public string Status { get; set; }
        public List<PackageWithChargeInfo> Pacakges { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class PackageWithChargeInfo
    {
        public int PackageTypeId { get; set; }
        public string PackageType { get; set; }
        public decimal PackageWidth { get; set; }
        public decimal PackageHeight { get; set; }
        public decimal PackageLength { get; set; }
        public string DimensionUnit { get; set; }
        public decimal PackageWeight { get; set; }
        public string WeightUnit { get; set; }
        public string PackageDetails { get; set; }
        public decimal PackageCharge { get; set; }
        public byte ActiveStatus { get; set; }
        public int UserId { get; set; }
    }
}
