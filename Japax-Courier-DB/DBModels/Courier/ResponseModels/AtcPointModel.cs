using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class AtcPointModel
    {
        public string Status { get; set; }
        public List<AtcPointInfo> AtcPoints { get; set; }
        public List<AtcPoints> AtcPointList { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class AtcPointInfo
    {
        public int AtcPointId { get; set; }
        public int CityDistrictId { get; set; }
        public string AtcPointName { get; set; }
        public string AtcPointAddress { get; set; }
        public int AtcPointAreaId { get; set; }
    }

    public class AtcPoints
    {
        public int CityDistrictId { get; set; }
        public string CityDistrictName { get; set; }
        public int PointId { get; set; }
        public string PointName { get; set; }
        public byte PointType { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string Address { get; set; }
        public string HouseOrRoadNo { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string Landmark { get; set; }
        public decimal Latitudes { get; set; }
        public decimal Longitudes { get; set; }
        public string ContactNo { get; set; }
        public byte ActiveStatus { get; set; }
        public int UserId { get; set; }
    }
}
