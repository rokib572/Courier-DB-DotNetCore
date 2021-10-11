using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdBannerInfo
    {
        public JcdBannerInfo()
        {
            JcdBannerDet = new HashSet<JcdBannerDet>();
        }

        public long BannerId { get; set; }
        public string BannerType { get; set; }
        public byte? BannerFor { get; set; }
        public string ShowInPage { get; set; }
        public string TemplateName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }
        public byte? ActiveStatus { get; set; }

        public virtual AdmnUserInfo User { get; set; }
        public virtual ICollection<JcdBannerDet> JcdBannerDet { get; set; }
    }
}
