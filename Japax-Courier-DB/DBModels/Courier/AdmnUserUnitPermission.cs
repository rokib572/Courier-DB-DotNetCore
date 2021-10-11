using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class AdmnUserUnitPermission
    {
        public int UserId { get; set; }
        public int UnitCode { get; set; }

        public virtual AdmnCompanyUnitInfo UnitCodeNavigation { get; set; }
        public virtual AdmnUserInfo User { get; set; }
    }
}
