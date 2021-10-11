using System;
using System.Collections.Generic;
using System.Text;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class CountryInfoModel
    {
        public string Status { get; set; }
        public string ExecutionTime { get; set; }
        public List<CountryInfo> Countries { get; set; }
        public CountryInfo Country { get; set; }
        public List<CountryDetails> CountryDetails { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class CountryInfo
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }

    public class CountryDetails
    {
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string TelephoneCode { get; set; }
        public string Notes { get; set; }
        public string LastUpdatedBy { get; set; }
        public byte ActiveStatus { get; set; }
    }
}
