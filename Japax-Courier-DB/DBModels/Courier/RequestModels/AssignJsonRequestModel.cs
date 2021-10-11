using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class AssignRequestModel
    {
        public List<long> RequestIds{ get; set; }
        public long DhId { get; set; }
        public long ManifestId { get; set; }
        public byte AssignFor { get; set; }
        public int AssignBy { get; set; }
        public int PickupPointId { get; set; }
        public int DropPointId { get; set; }
    }

    public class AssignJsonRequestModel
    {
        public long RequestId { get; set; }
        public long DhId { get; set; }
        public long ManifestId { get; set; }
        public byte AssignFor { get; set; }
        public int AssignBy { get; set; }
        public int PickupPointId { get; set; }
        public int DropPointId { get; set; }
    }
}
