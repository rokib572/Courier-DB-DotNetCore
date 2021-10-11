using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class ManifestInfoResponseModel
    {
		public string Status { get; set; }
		public List<ManifestInfo> ManifestInfo { get; set; }
		public ErrorModel Error { get; set; }
	}

    public class ManifestInfo
    {
		public long ManifestId { get; set; }
		public int PickupPointId { get; set; }
		public int DropPointId { get; set; }
		public int NoOfRequest { get; set; }
		public string TrackingNo { get; set; }
		public string ManifestStatus { get; set; }
		public string RequestId { get; set; }
	}
}
