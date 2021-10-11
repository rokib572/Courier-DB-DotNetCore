using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class ProvinceModel
    {
        public string Status { get; set; }
        public List<ProvicneInfo> States { get; set; }
        public List<ProvinceDetails> ProvinceDetails { get; set; }
        public ProvicneInfo State { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class ProvicneInfo
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CountryId { get; set; }
    }

    public class ProvinceDetails
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public byte ActiveStatus { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
