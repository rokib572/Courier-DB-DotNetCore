using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class CourierBannerDetailsRequestModel
    {
        public byte SlNo { get; set; }
        public string BannerImageLocation { get; set; }
    }

    public class CourierBannerDetailsUpdateModel
    {
        public long BannerId { get; set; }
        public byte SlNo { get; set; }
        public string BannerImageLocation { get; set; }
        public byte ActiveStatus { get; set; }
    }
}
