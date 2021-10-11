using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class ProvinceRequestModel
    {
        public int ProvinceId { get; set; }
        public string StateName { get; set; }
        public byte CountryId { get; set; }
        public int UserId { get; set; }
    }
}
