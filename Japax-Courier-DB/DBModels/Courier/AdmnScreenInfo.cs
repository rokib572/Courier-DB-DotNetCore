using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class AdmnScreenInfo
    {
        public AdmnScreenInfo()
        {
            AdmnUserRole = new HashSet<AdmnUserRole>();
        }

        public int ScreenId { get; set; }
        public string ScreenTitle { get; set; }
        public string FormName { get; set; }
        public string Url { get; set; }
        public string ScreenType { get; set; }
        public int? ParentScreenId { get; set; }
        public int ModuleId { get; set; }
        public int ScreenSorting { get; set; }
        public byte ScreenStatus { get; set; }

        public virtual AdmnModuleInfo Module { get; set; }
        public virtual ICollection<AdmnUserRole> AdmnUserRole { get; set; }
    }
}
