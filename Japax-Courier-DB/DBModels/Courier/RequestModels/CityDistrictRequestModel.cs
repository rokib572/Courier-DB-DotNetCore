using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class CityDistrictRequestModel
    {
        public int CityDistrictId { get; set; }
        public string CityDistrictName { get; set; }
        public byte ProvinceId { get; set; }
        public int UserId { get; set; }
    }
}
