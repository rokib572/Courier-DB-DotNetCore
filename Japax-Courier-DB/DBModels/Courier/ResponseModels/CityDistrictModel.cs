using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class CityDistrictModel
    {
        public string Status { get; set; }
        public string ExecutionTime { get; set; }
        public List<CityDistrictInfo> Cities { get; set; }
        public List<CityDistrictDetails> CityDistrictDetails { get; set; }
        public CityDistrictInfo City { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class CityDistrictInfo
    {
        public int CityDistrictId { get; set; }
        public string CityDistrictName { get; set; }
        public int ProvinceId { get; set; }
    }

    public class CityDistrictDetails
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public byte ActiveStatus { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
