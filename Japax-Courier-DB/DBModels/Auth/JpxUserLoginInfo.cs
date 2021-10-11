using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Auth
{
    public partial class JpxUserLoginInfo
    {
        public long LoginId { get; set; }
        public string UserMobileNo { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string ProfilePicture { get; set; }
        public string DeviceId { get; set; }
        public byte DeviceType { get; set; }
        public string FcmToken { get; set; }
        public string SecretKey { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public byte? ActiveStatus { get; set; }
        public DateTime? SetDate { get; set; }
        public byte CourierApp { get; set; }
        public byte RideshareApp { get; set; }
    }
}
