using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdLedgerInfo
    {
        public JcdLedgerInfo()
        {
            JcdMerchantOrStarUserTran = new HashSet<JcdMerchantOrStarUserTran>();
        }

        public byte LedgerId { get; set; }
        public string LedgerName { get; set; }
        public byte SysDefine { get; set; }

        public virtual ICollection<JcdMerchantOrStarUserTran> JcdMerchantOrStarUserTran { get; set; }
    }
}
