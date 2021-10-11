using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class DhProfileResponseModel
    {
        public string Status { get; set; }
        public DhInfoModel DhInfo { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class DhInfoModel    {
        public long DhId { get; set; }
        public string DhCode { get; set; }
        public string DhFirstName { get; set; }
        public string DhMiddleName { get; set; }
        public string DhLastName { get; set; }
        public string DhMobNo { get; set; }
        public byte DhType { get; set; }
        public byte AssignTeam { get; set; }
        public byte DefaultAssignRole { get; set; }
        public string TransportType { get; set; }
        public string TransportDescription { get; set; }
        public string LicencePlate { get; set; }
        public string TransportColor { get; set; }
        public string DhEmailAddr { get; set; }
        public DateTime JoiningDate { get; set; }
        public string DhImage { get; set; }
        public string FcmToken { get; set; }
        public string DeviceId { get; set; }
    }

}
