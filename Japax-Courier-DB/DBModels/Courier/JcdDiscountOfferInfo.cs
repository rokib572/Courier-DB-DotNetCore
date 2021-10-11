using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdDiscountOfferInfo
    {
        public long DiscountId { get; set; }
        public long SenderId { get; set; }
        public byte DiscountOn { get; set; }
        public byte CalculateBy { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }
        public byte? ActiveStatus { get; set; }

        public virtual JcdSenderInfo Sender { get; set; }
        public virtual AdmnUserInfo User { get; set; }
    }
}
