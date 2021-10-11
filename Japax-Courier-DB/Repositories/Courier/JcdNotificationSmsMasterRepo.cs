using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.Clients;
using Japax_Courier_DB.DBModels.Auth.Models.Response;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Japax_Courier_DB.FcmMessaging;
using Japax_Courier_DB.Repositories.Auth;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Japax_Courier_DB.DBModels.CommonModels;
using System.Net.Http;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdNotificationSmsMasterRepo
    {
        JpxCourierContext Context = new JpxCourierContext();
        JcdPickupAndDeliveryRequestRepo requestRepo = new JcdPickupAndDeliveryRequestRepo();
        private string AdminNotificationUrl = "http://admin.atc.co.bd/api/Notification/GetNotification";
        public async Task<CommonResponseModel> AddNotificationSmsMaster(NotificationSmsRequestModel Request)
        {
            try
            {
                await Context.Database
                                .ExecuteSqlRawAsync($"SP_JCD_NOTIFICATION_SMS_MASTER_OPERATION @P_OPT_ID = 'I', " +
                                                    $"@P_NOTIFICATION_ID = {Request.NotificationId}," +
                                                    $"@P_SEND_NOTIFICATION = {Request.SendNotification}," +
                                                    $"@P_SEND_NOTIFICATION_TO = '{Request.SendNotificationTo}'," +
                                                    $"@P_NOTIFICATION_TITLE = '{Request.NotificationTitle}'," +
                                                    $"@P_NOTIFICATION_MESSAGE = '{Request.NotificationMessage}'," +
                                                    $"@P_SEND_SMS = {Request.SendSms}," +
                                                    $"@P_SEND_SMS_TO = '{Request.SendSmsTo}'," +
                                                    $"@P_SMS_MESSAGE = '{Request.SmsMessage}'," +
                                                    $"@P_USER_ID = {Request.UserId}");

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success",
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "AddNotificationSmsMaster",
                    ErrMethodPayload = JsonConvert.SerializeObject(Request),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Response);
            }
        }
        public async Task<CommonResponseModel> UpdateNotificationSmsMaster(NotificationSmsRequestModel Request)
        {
            try
            {
                await Context.Database
                                .ExecuteSqlRawAsync($"SP_JCD_NOTIFICATION_SMS_MASTER_OPERATION @P_OPT_ID = 'U', " +
                                                    $"@P_ID = {Request.MasterId}," +
                                                    $"@P_NOTIFICATION_ID = {Request.NotificationId}," +
                                                    $"@P_SEND_NOTIFICATION = {Request.SendNotification}," +
                                                    $"@P_SEND_NOTIFICATION_TO = '{Request.SendNotificationTo}'," +
                                                    $"@P_NOTIFICATION_TITLE = '{Request.NotificationTitle}'," +
                                                    $"@P_NOTIFICATION_MESSAGE = '{Request.NotificationMessage}'," +
                                                    $"@P_SEND_SMS = {Request.SendSms}," +
                                                    $"@P_SEND_SMS_TO = '{Request.SendSmsTo}'," +
                                                    $"@P_SMS_MESSAGE = '{Request.SmsMessage}'," +
                                                    $"@P_USER_ID = {Request.UserId}");

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success",
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "UpdateNotificationSmsMaster",
                    ErrMethodPayload = JsonConvert.SerializeObject(Request),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Response);
            }
        }
        public async Task<CommonResponseModel> ChangeNotificationSmsMasterStatus(int MasterId, byte Status, int UserId)
        {
            try
            {
                await Context.Database
                                .ExecuteSqlRawAsync($"SP_JCD_NOTIFICATION_SMS_MASTER_OPERATION @P_OPT_ID = 'C', " +
                                                    $"@P_ID = {MasterId}," +
                                                    $"@P_ACTIVE_STATUS = {Status}," +
                                                    $"@P_USER_ID = {UserId}");

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success",
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "ChangeNotificationSmsMasterStatus",
                    ErrMethodPayload = "MasterId => " + MasterId + ", Status => " + Status + ", UserId => " + UserId,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Response);
            }
        }
        public async Task<NotificationSmsResponseModel> GetAllNotificationSmsMaster()
        {
            try
            {
                List<NotificationSmsInfo> NotificationInfo = await Context.NotificationSmsInfo
                                                                .FromSqlRaw($"SP_JCD_NOTIFICATION_SMS_MASTER_OPERATION " +
                                                                            $"@P_OPT_ID = 'O'")
                                                                .ToListAsync();

                NotificationSmsResponseModel Response = new NotificationSmsResponseModel
                {
                    Status = "Success",
                    NotificationInfo = NotificationInfo
                };

                return await Task.FromResult(Response);
            } catch (Exception ex)
            {
                NotificationSmsResponseModel Response = new NotificationSmsResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "GetAllNotificationSmsMaster",
                    ErrMethodPayload = "",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Response);

            }
        }
        public async Task<NotificationSmsResponseModel> GetActiveNotificationSmsMaster()
        {
            try
            {
                List<NotificationSmsInfo> NotificationInfo = await Context.NotificationSmsInfo
                                                                .FromSqlRaw($"SP_JCD_NOTIFICATION_SMS_MASTER_OPERATION " +
                                                                            $"@P_OPT_ID = 'A'")
                                                                .ToListAsync();

                NotificationSmsResponseModel Response = new NotificationSmsResponseModel
                {
                    Status = "Success",
                    NotificationInfo = NotificationInfo
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                NotificationSmsResponseModel Response = new NotificationSmsResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "GetActiveNotificationSmsMaster",
                    ErrMethodPayload = "",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Response);

            }
        }
        public async Task<NotificationSmsResponseModel> GetNotificationSmsMasterById(int MasterId)
        {
            try
            {
                List<NotificationSmsInfo> NotificationInfo = await Context.NotificationSmsInfo
                                                                .FromSqlRaw($"SP_JCD_NOTIFICATION_SMS_MASTER_OPERATION " +
                                                                            $"@P_OPT_ID = 'G'," +
                                                                            $"@P_ID = {MasterId}")
                                                                .ToListAsync();

                NotificationSmsResponseModel Response = new NotificationSmsResponseModel
                {
                    Status = "Success",
                    NotificationInfo = NotificationInfo
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                NotificationSmsResponseModel Response = new NotificationSmsResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "GetNotificationSmsMasterById",
                    ErrMethodPayload = "MasterId => " + MasterId,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Response);

            }
        }
        public async Task<NotificationSmsResponseModel> GetNotificationSmsMasterByNotificationId(byte NotificationId)
        {
            try
            {
                List<NotificationSmsInfo> NotificationInfo = await Context.NotificationSmsInfo
                                                                .FromSqlRaw($"SP_JCD_NOTIFICATION_SMS_MASTER_OPERATION " +
                                                                            $"@P_OPT_ID = 'N'," +
                                                                            $"@P_NOTIFICATION_ID = {NotificationId}")
                                                                .ToListAsync();

                NotificationSmsResponseModel Response = new NotificationSmsResponseModel
                {
                    Status = "Success",
                    NotificationInfo = NotificationInfo
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                NotificationSmsResponseModel Response = new NotificationSmsResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                    }
                };

                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "GetNotificationSmsMasterByNotificationId",
                    ErrMethodPayload = "NotificationId => " + NotificationId,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Response);

            }
        }
        public async Task<string> SendNotification(byte notificationId, long dhId=0, List<long> requestIds=null)
        {
            JcdNotificationSmsMasterRepo NotificationSmsMasterRepo = new JcdNotificationSmsMasterRepo();
            NotificationSmsResponseModel NotificationSettings = await NotificationSmsMasterRepo.GetNotificationSmsMasterByNotificationId(notificationId);

            foreach(NotificationSmsInfo notificationInfo in NotificationSettings.NotificationInfo)
            {
                if (notificationInfo.SendNotification == "YES")
                {
                    List<string> sendNotToList = notificationInfo.NotificationTo.Split(" | ").ToList();

                    foreach (string sendNot in sendNotToList)
                    {
                        if (sendNot == "DELIVERY HERO")
                        {
                            if(dhId > 0)
                            {
                                JcdDeliveryHeroInfoRepo DhRepo = new JcdDeliveryHeroInfoRepo();

                                DeliveryHeroInfoResponseModel DhInfo = await DhRepo.GetDhById(dhId);
                                FcmClient fcmClient = new FcmClient();
                                List<string> FcmKeyList = new List<string>();
                                FcmKeyList.Add(DhInfo.DeliveryHero.FcmToken);
                                string notificationTitle = notificationInfo.NotificationTitle.Replace("{requestId}", string.Join<long>(",", requestIds));
                                await fcmClient.SendNotification(FcmKeyList, notificationTitle, notificationInfo.NotificationMessage);
                            }
                        }
                        else if (sendNot == "SENDER")
                        {
                            foreach (long requestId in requestIds)
                            {
                                long SenderId = await requestRepo.GetSenderIdByRequest(requestId);

                                //send notification to Sender
                                JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
                                JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(SenderId));

                                FcmClient fcmClient = new FcmClient();
                                List<string> FcmKeyList = new List<string>();
                                FcmKeyList.Add(_UserAuth.UserInfo.FcmToken);
                                string notificationTitle = notificationInfo.NotificationTitle.Replace("{requestId}", requestId.ToString());
                                await fcmClient.SendNotification(FcmKeyList, notificationTitle, notificationInfo.NotificationMessage);
                            }
                        }
                        else if (sendNot == "RECEIVER")
                        {
                            foreach (long requestId in requestIds)
                            {
                                //Send notification to Receiver
                                string receiverPhone = await requestRepo.GetReceiverPhoneByRequest(requestId);
                                
                                JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
                                JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserByPhone(receiverPhone);

                                if(_UserAuth.UserInfo !=null)
                                {
                                    FcmClient fcmClient = new FcmClient();
                                    List<string> FcmKeyList = new List<string>();
                                    FcmKeyList.Add(_UserAuth.UserInfo.FcmToken);
                                    string notificationTitle = notificationInfo.NotificationTitle.Replace("{requestId}", requestId.ToString());
                                    await fcmClient.SendNotification(FcmKeyList, notificationTitle, notificationInfo.NotificationMessage);
                                }
                            }
                        }
                        else if (sendNot == "ADMIN")
                        {
                            //Send Notification to Admin
                            string notificationTitle = notificationInfo.NotificationTitle.Replace("{requestId}", string.Join<long>(",", requestIds));

                            AdminNotificationPayloadModel PayLoad = new AdminNotificationPayloadModel
                            {
                                NotificationTitle = notificationTitle,
                                NotificationMessage = notificationInfo.NotificationMessage
                            };

                            var formData = new StringContent(JsonConvert.SerializeObject(PayLoad), Encoding.UTF8, "application/json");

                            var request = new HttpRequestMessage(HttpMethod.Post, AdminNotificationUrl)
                            {
                                Content = formData
                            };

                            HttpClient client = new HttpClient();

                            //await client.SendAsync(request);
                        }
                    }
                }

                if (notificationInfo.SendSms == "YES")
                {
                    List<string> sendSmsToList = notificationInfo.SendSmsTo.Split(" | ").ToList();

                    foreach (string sendNot in sendSmsToList)
                    {
                        if (sendNot == "DELIVERY HERO")
                        {
                            JcdDeliveryHeroInfoRepo DhRepo = new JcdDeliveryHeroInfoRepo();
                            DeliveryHeroInfoResponseModel DhInfo = await DhRepo.GetDhById(dhId);
                            SMSClient smsClient = new SMSClient();
                            string smsMessage = notificationInfo.SmsMessage.Replace("{requestId}", string.Join<long>(",", requestIds));
                            await smsClient.SendSms(DhInfo.DeliveryHero.DhMobNo, smsMessage);
                        }
                        else if (sendNot == "SENDER")
                        {
                            foreach (long requestId in requestIds)
                            {
                                long SenderId = await requestRepo.GetSenderIdByRequest(requestId);

                                //send notification to Sender
                                JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
                                JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(SenderId));
                                SMSClient smsClient = new SMSClient();
                                string smsMessage = notificationInfo.SmsMessage.Replace("{requestId}", requestId.ToString());
                                await smsClient.SendSms(_UserAuth.UserInfo.UserMobileNo, smsMessage);
                            }
                        }
                        else if (sendNot == "RECEIVER")
                        {
                            //Send sms to Receiver
                            foreach (long requestId in requestIds)
                            {
                                string receiverPhone = await requestRepo.GetReceiverPhoneByRequest(requestId);

                                JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
                                JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserByPhone(receiverPhone);

                                if (_UserAuth.UserInfo != null)
                                {
                                    SMSClient smsClient = new SMSClient();
                                    string smsMessage = notificationInfo.SmsMessage.Replace("{requestId}", requestId.ToString());
                                    await smsClient.SendSms(_UserAuth.UserInfo.UserMobileNo, smsMessage);
                                }
                            }
                        }
                    }
                }
            }

            return await Task.FromResult("Success");
        }
    }
}
