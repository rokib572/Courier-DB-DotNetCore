using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class CourierBannerInfo
    {
        public long BannerId { get; set; }
        public string BannerType { get; set; }
        public string ShowInPage { get; set; }
        public string TemplateName { get; set; }
        public List<CourierBannerDetailsResponseModel> BannerDetailsModel { get; set; }
    }
    public class CourierBannerDetailsResponseModel
    {
        public byte SlNo { get; set; }
        public string BannerImageLocation { get; set; }
    }
}
