using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class TrackingDetailsResponseModel
    {
        public string Status { get; set; }
        public List<TrackingDetails> TrackingDetails { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class TrackingDetails
    {
        public long LogId { get; set; }
        public long RequestId { get; set; }
        public string Status { get; set; }
        public DateTime NotificationTime { get; set; }
    }
}
