using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Japax_Courier_DB.DBModels.CommonModels
{
    public class SmsRequestModel
    {
        [JsonProperty("api_token")]
        public string ApiToken { get; set; }

        [JsonProperty ("sid")]
        public string MaskingName { get; set; }
        
        [JsonProperty ("msisdn")]
        public string MobileNumber { get; set; }

        [JsonProperty ("sms")]
        public string Message { get; set; }

        [JsonProperty ("csms_id")]
        public string UniqueId { get; set; }
    }
}
