using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class AdmnCompanyInfo
    {
        public AdmnCompanyInfo()
        {
            AdmnCompanyUnitInfo = new HashSet<AdmnCompanyUnitInfo>();
        }

        public int CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }
        public int EntryUser { get; set; }
        public DateTime EntryDate { get; set; }

        public virtual ICollection<AdmnCompanyUnitInfo> AdmnCompanyUnitInfo { get; set; }
    }
}
