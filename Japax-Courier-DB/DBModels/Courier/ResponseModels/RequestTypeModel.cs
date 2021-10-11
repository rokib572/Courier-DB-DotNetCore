using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class RequestTypeModel
    {
        public string Status { get; set; }
        public List<RequestTypeInfo> RequestTypes { get; set; }
        public RequestTypeInfo RequestType { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class RequestTypeInfo
    {
        public int RequestTypeId { get; set; }
        public string RequestType { get; set; }
        public int ShowToClient { get; set; }
        public int ShowToDH { get; set; }
    }
}
