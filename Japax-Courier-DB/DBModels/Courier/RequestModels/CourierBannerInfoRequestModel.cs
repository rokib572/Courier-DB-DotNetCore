using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class CourierBannerInfoRequestModel
    {
        public string BannerType { get; set; }
        public byte BannerFor { get; set; }
        public string ShowInPage { get; set; }
        public string TemplateName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int UserId { get; set; }
    }

    public class CourierBannerInfoUpdateModel
    {
        public long BannerId { get; set; }
        public string BannerType { get; set; }
        public byte BannerFor { get; set; }
        public string ShowInPage { get; set; }
        public string TemplateName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int UserId { get; set; }
        public byte ActiveStatus { get; set; }
    }
}
