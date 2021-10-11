using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class AtcPointRequestModel
    {
        public int PointId { get; set; }
        public string PointName { get; set; }
        public byte PointType { get; set; }
        public int AreaId { get; set; }
        public string Address { get; set; }
        public string HouseOrRoadNo { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string Landmark { get; set; }
        public decimal Latitudes { get; set; }
        public decimal Longitudes { get; set; }
        public string ContactNo { get; set; }
        public int UserId { get; set; }
    }
}
