using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdDeliveryHeroExp
    {
        public long Id { get; set; }
        public long DhId { get; set; }
        public string ExperiencePeriod { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string JobTitle { get; set; }
        public string KeyResponsibilities { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdDeliveryHeroInfo Dh { get; set; }
        public virtual AdmnUserInfo User { get; set; }
    }
}
