using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class UpazillaModel
    {
        public string Status { get; set; }
        public List<UpazillaInfo> Upazillas { get; set; }
        public List<UpazillaDetails> UpazillaDetails { get; set; }
        public UpazillaInfo Upazilla { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class UpazillaInfo
    {
        public int PsUpazilaId { get; set; }
        public string PsUpazilaName { get; set; }
        public int CityDistrictId { get; set; }
        public byte UnderCityCorporation { get; set; }
    }

    public class UpazillaDetails
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
        public string LastUpdatedBy { get; set; }
        public byte ActiveStatus { get; set; }
    }
}
