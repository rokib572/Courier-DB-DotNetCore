using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class ProductImageRequestModel
    {
        public long RequestId { get; set; }
        public byte ProductSL { get; set; }
        public string ProductImage { get; set; }
        public string TrackingNumber { get; set; }
    }
}
