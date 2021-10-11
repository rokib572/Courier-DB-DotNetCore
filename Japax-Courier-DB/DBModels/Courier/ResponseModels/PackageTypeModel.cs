using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class PackageTypeModel
    {
        public string Status { get; set; }
        public List<PackageTypeInfo> PackageTypes { get; set; }
        public PackageTypeInfo PackageType { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class PackageTypeInfo
    {
        public int PackageChargeId { get; set; }
        public string PackageType { get; set; }
        public string PackageHeight { get; set; }
        public string PackageWidth { get; set; }
        public string PackageLength { get; set; }
        public string DimensionUnit { get; set; }
        public string PackageWeight { get; set; }
        public string WeightUnit { get; set; }
        public string PackageDetails { get; set; }        
    }
}
