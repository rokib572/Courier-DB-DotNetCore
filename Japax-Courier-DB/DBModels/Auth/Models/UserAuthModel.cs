using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Auth.Models
{
    public class UserAuthModel
    {
        public long UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string FCMKey { get; set; }
        public string DeviceId { get; set; }
        public string SecretKey { get; set; }
        public UserProfileModel UserProfile { get; set; }
    }
}
