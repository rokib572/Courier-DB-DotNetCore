using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdManifestDetails
    {
        public long ManifestId { get; set; }
        public long RequestId { get; set; }

        public virtual JcdManifestInfo Manifest { get; set; }
        public virtual JcdPickupAndDeliveryRequest Request { get; set; }
    }
}
