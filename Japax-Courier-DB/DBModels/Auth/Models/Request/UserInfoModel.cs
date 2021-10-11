using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Auth.Models.Request
{
    public class UserInfoModel
    {
        public string UserMobileNo { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string DeviceId { get; set; }
        public byte DeviceType { get; set; }
        public string FcmToken { get; set; }
        public byte CourierApp { get; set; }
        public byte RideshareApp { get; set; }
        public byte SenderType { get; set; }
    }
}
