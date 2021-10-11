using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdMerchantOrStarUserTran
    {
        public long SysVrno { get; set; }
        public DateTime TranDate { get; set; }
        public long SenderId { get; set; }
        public long RequestId { get; set; }
        public byte LedgerId { get; set; }
        public string LedgerName { get; set; }
        public string Description { get; set; }
        public decimal DebitAmt { get; set; }
        public decimal CreditAmt { get; set; }

        public virtual JcdLedgerInfo Ledger { get; set; }
        public virtual JcdPickupAndDeliveryRequest Request { get; set; }
        public virtual JcdSenderInfo Sender { get; set; }
    }
}
