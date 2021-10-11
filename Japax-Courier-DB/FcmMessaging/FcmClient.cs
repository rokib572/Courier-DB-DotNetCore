using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FCM.Net;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.Repositories.Courier;
using Newtonsoft.Json;

namespace Japax_Courier_DB.FcmMessaging
{
    public class FcmClient
    {
        private string ServerKey = "AAAAr_dqFqc:APA91bG5D9DtgJuFVszT0n5aNQtK74NJCjF9gG4Vm3qoZTRsU38aLuxADRFX0WzDo0dwMY1u2tZ6TTtDyuEfbV6jP9nGVg55VAxz8mwc4MvuczujPlWkSsZho3vya08-EWpg5qvqpQxW";

        public async Task<string> SendNotification(List<string> FcmKey, string title, string body, object CustomPayload = null)
        {
            try
            {
                string GoogleFCMUrl = "https://fcm.googleapis.com/fcm/send";

                FcmModel PayLoad = new FcmModel
                {
                    registration_ids = FcmKey,
                    notification = new Notification
                    {
                        title = title,
                        text = body
                    },
                    data = CustomPayload
                };
                var formData = new StringContent(JsonConvert.SerializeObject(PayLoad), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, GoogleFCMUrl)
                {
                    Content = formData
                };
                request.Headers.TryAddWithoutValidation("Authorization", "key=" + ServerKey);

                HttpClient client = new HttpClient();

                var response = await client.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                FcmResponseModel ResponseModel = JsonConvert.DeserializeObject<FcmResponseModel>(result);

                if (ResponseModel.success == 1)
                {
                    return await Task.FromResult("Success");
                }
                else
                {
                    return await Task.FromResult(ResponseModel.results[0].error);
                }
            } catch (Exception ex)
            {
                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "SendNotification",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult("Something went wrong.");
            }                  
        }
    }
}
