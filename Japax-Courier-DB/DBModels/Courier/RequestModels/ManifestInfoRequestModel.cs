using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class ManifestInfoRequestModel
    {
		public string RequestId { get; set; }
		public long ManifestId { get; set; }
		public int PickupPointId { get; set; }
		public int DropPointId { get; set; }
		public int NoOfRequest { get; set; }
		public string TrackingNo { get; set; }
		public byte ManifestStatus { get; set; }
		public int UserId { get; set; }
    }
}
