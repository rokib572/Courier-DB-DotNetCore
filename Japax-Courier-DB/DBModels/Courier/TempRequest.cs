using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class TempRequest
    {
        public long? TempRequestId { get; set; }
        public long? TempDhId { get; set; }
        public long? TempManifestId { get; set; }
        public byte? TempAssignFor { get; set; }
        public DateTime? TempAssignDate { get; set; }
        public int? TempAssignBy { get; set; }
        public int? TempPickupPointId { get; set; }
        public int? TempDropPointId { get; set; }
    }
}
