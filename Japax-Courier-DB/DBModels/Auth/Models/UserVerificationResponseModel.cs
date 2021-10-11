using System;
using System.Collections.Generic;
using System.Text;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Newtonsoft.Json;

namespace Japax_Courier_DB.DBModels.Auth.Models
{
    public class UserVerificationResponseModel
    {
        public string Status { get; set; }
        public long LoginId { get; set; }
        public string UserMobileNo { get; set; }
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string ProfilePicture { get; set; }
        public string DeviceId { get; set; }
        public byte DeviceType { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public byte? ActiveStatus { get; set; }
        public byte CourierApp { get; set; }
        public byte RideshareApp { get; set; }
        public string SecretKey { get; set; }
        public byte? SenderType { get; set; }

        [JsonProperty("error")]
        public ErrorModel Error { get; set; }
    }
}
