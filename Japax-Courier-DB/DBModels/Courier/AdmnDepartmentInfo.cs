using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class AdmnDepartmentInfo
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptShortName { get; set; }
        public string DeptIncharge { get; set; }
        public int EntryUser { get; set; }

        public virtual AdmnUserInfo EntryUserNavigation { get; set; }
    }
}
