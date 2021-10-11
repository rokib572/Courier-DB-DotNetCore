using System;
using System.Collections.Generic;
using System.Text;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class JcdSenderInfoModel
    {
        public string Status { get; set; }
        public JcdSenderInfo SenderInfo { get; set; }
        public ErrorModel Error { get; set; }
    }
}
