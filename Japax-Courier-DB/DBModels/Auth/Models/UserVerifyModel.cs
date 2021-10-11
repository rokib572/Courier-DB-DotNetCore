using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Japax_Courier_DB.DBModels.Auth.Models
{
    public class UserVerifyModel
    {
        public string PhoneNumber { get; set; }
        public string DeviceId { get; set; }
        public string FCMToken { get; set; }
        public byte DeviceType { get; set; }
        public byte CourierApp { get; set; }
        public byte RideshareApp { get; set; }
    }
}
