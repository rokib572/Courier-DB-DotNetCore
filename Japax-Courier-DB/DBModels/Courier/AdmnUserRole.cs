using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class AdmnUserRole
    {
        public int UserId { get; set; }
        public int UnitCode { get; set; }
        public int ScreenId { get; set; }
        public byte ViewPerm { get; set; }
        public byte InsertPerm { get; set; }
        public byte UpdatePerm { get; set; }
        public byte DeletePerm { get; set; }
        public byte ApprovePerm { get; set; }
        public int PermittedBy { get; set; }
        public DateTime? PermitDate { get; set; }

        public virtual AdmnScreenInfo Screen { get; set; }
        public virtual AdmnCompanyUnitInfo UnitCodeNavigation { get; set; }
        public virtual AdmnUserInfo User { get; set; }
    }
}
