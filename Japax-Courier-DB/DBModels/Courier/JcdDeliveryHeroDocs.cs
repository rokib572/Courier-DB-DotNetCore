using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdDeliveryHeroDocs
    {
        public long Id { get; set; }
        public long DhId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentLocation { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdDeliveryHeroInfo Dh { get; set; }
        public virtual AdmnUserInfo User { get; set; }
    }
}
