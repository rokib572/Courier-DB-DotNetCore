using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdDiscountOfferDet
    {
        public long DiscountId { get; set; }
        public decimal RangeFrom { get; set; }
        public decimal RangeTo { get; set; }
        public decimal DiscountAmtOrPer { get; set; }

        public virtual JcdDiscountOfferInfo Discount { get; set; }
    }
}
