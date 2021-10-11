using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdProductPackageRate
    {
        public JcdProductPackageRate()
        {
            JcdProductDetails = new HashSet<JcdProductDetails>();
        }

        public byte ExtraPackingId { get; set; }
        public string PackageType { get; set; }
        public decimal PackageRate { get; set; }

        public virtual ICollection<JcdProductDetails> JcdProductDetails { get; set; }
    }
}
