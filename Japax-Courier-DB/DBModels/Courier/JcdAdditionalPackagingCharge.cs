using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdAdditionalPackagingCharge
    {
        public JcdAdditionalPackagingCharge()
        {
            JcdProductDetails = new HashSet<JcdProductDetails>();
        }

        public byte ExtraPackagingId { get; set; }
        public string PackagingType { get; set; }
        public decimal PackagingCharge { get; set; }
        public byte? ActiveStatus { get; set; }

        public virtual ICollection<JcdProductDetails> JcdProductDetails { get; set; }
    }
}
