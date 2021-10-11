using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class ExtraPackagingTypeModel
    {
        public string Status { get; set; }
        public List<ExtraPackagingTypeInfo> ExtraPackageTypes { get; set; }
        public ExtraPackagingTypeInfo ExtraPackageType { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class ExtraPackagingTypeInfo
    {
        public byte ExtraPackagingId { get; set; }
        public string PackagingType { get; set; }
        public decimal PackagingCharge { get; set; }
        public byte ActiveStatus { get; set; }
    }
}
