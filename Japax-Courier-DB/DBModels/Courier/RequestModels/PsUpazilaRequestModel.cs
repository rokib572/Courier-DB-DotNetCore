using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class PsUpazilaRequestModel
    {
        public int PsUpazilaId { get; set; }
        public string PsUpazilaName { get; set; }
        public int CityDistrictId { get; set; }
        public byte UnderCityCorporation { get; set; }
        public int UserId { get; set; }
    }
}
