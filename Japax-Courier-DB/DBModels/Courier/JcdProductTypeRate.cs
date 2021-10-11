using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdProductTypeRate
    {
        public JcdProductTypeRate()
        {
            JcdProductDetails = new HashSet<JcdProductDetails>();
        }

        public byte ProductTypeId { get; set; }
        public string ProductType { get; set; }
        public decimal ProductTypeRate { get; set; }

        public virtual ICollection<JcdProductDetails> JcdProductDetails { get; set; }
    }
}
