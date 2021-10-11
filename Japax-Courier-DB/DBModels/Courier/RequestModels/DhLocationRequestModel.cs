using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class DhLocationRequestModel
    {
        public long DhId { get; set; }
        public long RequestId { get; set; }
        public DateTime? LogTime { get; set; }
        public decimal LatitudesData { get; set; }
        public decimal LongitudesData { get; set; }
    }
}
