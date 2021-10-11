using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class CountryRequestModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string TelephoneCode { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
        public byte ActiveStatus { get; set; }
    }
}
