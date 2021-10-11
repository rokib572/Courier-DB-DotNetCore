using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class CourierBannerResponseModel
    {
        public string Status { get; set; }
        public List<CourierBannerInfo> BannerInfoModel { get; set; }
        public ErrorModel Error { get; set; }
    }
}
