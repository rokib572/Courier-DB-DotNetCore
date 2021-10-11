using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Clients
{
    public class SMSClient
    {
        private string APIEndPoint = "https://smsplus.sslwireless.com/api/v3/send-sms";
        private string APIToken = "ATC-b0f7a917-cc29-4783-8f99-b1ac53f0ae85";
        public async Task<SmsResponseModel> SendSms(string phoneNumber, string smsMessage)
        {
            using HttpClient httpClient = new HttpClient();

            SmsRequestModel smsModel = new SmsRequestModel
            {
                ApiToken = APIToken,
                MaskingName = "ATCNONMASK",
                Message = smsMessage,
                MobileNumber = phoneNumber,
                UniqueId = Guid.NewGuid().ToString()
            };

            string RequestString = JsonConvert.SerializeObject(smsModel);
            var bodyContent = new StringContent(RequestString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(APIEndPoint, bodyContent);
            string result = await response.Content.ReadAsStringAsync();

            return await Task.FromResult(JsonConvert.DeserializeObject<SmsResponseModel>(result));
        }
    }
}
