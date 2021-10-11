using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class PickupAndDeliveryAreaModel
    {
        public string Status { get; set; }
        public List<AreaInfo> Areas { get; set; }
        public List<AreaDetails> AreaDetails { get; set; }
        public AreaInfo Area { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class AreaInfo
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int PsUpazilaId { get; set; }
        public int CityDistrictId { get; set; }
        public string AreaPolygon { get; set; }
        public byte? ZoneId { get; set; }
    }

    public class AreaDetails
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int UpazilaId { get; set; }
        public string UpazilaName { get; set; }
        public byte UnderCityCorporation { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string AreaPolygon { get; set; }
        public string LastUpdatedBy { get; set; }
        public byte ActiveStatus { get; set; }
    }
}
