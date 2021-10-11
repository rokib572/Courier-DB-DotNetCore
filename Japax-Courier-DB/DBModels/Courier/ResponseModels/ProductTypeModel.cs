using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class ProductTypeModel
    {
        public string Status { get; set; }
        public List<ProductTypeInfo> ProductTypes { get; set; }
        public ProductTypeInfo ProductType { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class ProductTypeInfo
    {
        public int ProductTypeId { get; set; }
        public string ProductType { get; set; }
        public decimal HandlingCharge { get; set; }
        public byte ActiveStatus { get; set; }
    }
}
