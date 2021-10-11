using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class AreaRequestModel
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int PsUpazilaId { get; set; }
        public byte ZoneId { get; set; }
        public string AreaPolygon { get; set; }
        public int UserId { get; set; }
        public byte ActiveStatus { get; set; }
    }
}
