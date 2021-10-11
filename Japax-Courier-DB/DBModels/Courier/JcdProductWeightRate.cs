using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdProductWeightRate
    {
        public JcdProductWeightRate()
        {
            JcdProductDetails = new HashSet<JcdProductDetails>();
        }

        public byte ProductWeightId { get; set; }
        public string ProductWeight { get; set; }
        public decimal WeightRate { get; set; }

        public virtual ICollection<JcdProductDetails> JcdProductDetails { get; set; }
    }
}
