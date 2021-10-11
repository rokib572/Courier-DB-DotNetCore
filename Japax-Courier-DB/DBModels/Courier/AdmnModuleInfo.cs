using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class AdmnModuleInfo
    {
        public AdmnModuleInfo()
        {
            AdmnScreenInfo = new HashSet<AdmnScreenInfo>();
        }

        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int ModuleSorting { get; set; }
        public byte ModuleStatus { get; set; }

        public virtual ICollection<AdmnScreenInfo> AdmnScreenInfo { get; set; }
    }
}
