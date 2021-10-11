using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class AssignResponseModel
    {
        public string Status { get; set; }
        public List<AssignJsonRequestModel> AssignRequestList { get; set; }
        public ErrorModel Error { get; set; }
    }
}
