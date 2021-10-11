using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.CommonModels.Response
{
    public class CommonResponseModel
    {
        public string Status { get; set; }
        public string ExecutionTime { get; set; }
        public ErrorModel Error { get; set; }
    }
}
