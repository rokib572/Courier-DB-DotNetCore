using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdBannerDet
    {
        public long BannerId { get; set; }
        public byte SlNo { get; set; }
        public string BannerImageLocation { get; set; }
        public byte? ActiveStatus { get; set; }

        public virtual JcdBannerInfo Banner { get; set; }
    }
}
