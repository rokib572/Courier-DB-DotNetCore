using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdProductType
    {
        public JcdProductType()
        {
            JcdProductDetails = new HashSet<JcdProductDetails>();
        }

        public int ProductTypeId { get; set; }
        public string ProductType { get; set; }
        public decimal HandlingCharge { get; set; }
        public byte? ActiveStatus { get; set; }

        public virtual ICollection<JcdProductDetails> JcdProductDetails { get; set; }
    }
}
