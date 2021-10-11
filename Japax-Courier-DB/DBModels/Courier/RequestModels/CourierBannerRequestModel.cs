using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class CourierBannerRequestModel
    {
        public CourierBannerInfoRequestModel BannerInfoModel { get; set; }
        public List<CourierBannerDetailsRequestModel> BannerDetailsModel { get; set; }
    }

    public class CourierBannerUpdateModel
    {
        public CourierBannerInfoUpdateModel BannerInfoModel { get; set; }
        public List<CourierBannerDetailsUpdateModel> BannerDetailsModel { get; set; }
    }
}
