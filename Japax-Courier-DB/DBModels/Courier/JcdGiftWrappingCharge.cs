using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdGiftWrappingCharge
    {
        public JcdGiftWrappingCharge()
        {
            JcdProductDetails = new HashSet<JcdProductDetails>();
        }

        public byte GiftWrappingId { get; set; }
        public string WrappingType { get; set; }
        public decimal WrappingCharge { get; set; }
        public byte? ActiveStatus { get; set; }

        public virtual ICollection<JcdProductDetails> JcdProductDetails { get; set; }
    }
}
