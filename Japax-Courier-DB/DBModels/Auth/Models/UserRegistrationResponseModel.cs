using System;
using System.Collections.Generic;
using System.Text;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Newtonsoft.Json;

namespace Japax_Courier_DB.DBModels.Auth.Models
{
    public class UserRegistrationResponseModel
    {
        public string Status { get; set; }
        public JpxUserLoginInfo LoginInfo { get; set; }

        [JsonProperty("Error")]
        public ErrorModel Error { get; set; }
    }
}
