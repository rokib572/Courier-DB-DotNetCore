using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdNotificationMessagesRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<CommonResponseModel> AddNotificationMessage (NotificationMesasge Request)
        {
            try
            {
                await Context.Database
                                .ExecuteSqlRawAsync($"SP_JCD_NOTIFICATION_MESSAGE_OPERATION @P_OPT_ID = 'I', " +
                                                    $"@P_NOTIFICATION_MSG = '{Request.NotificationMessage}'");

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
                    ErrMethod = "AddNotificationMessage",
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
        public async Task<CommonResponseModel> UpdateNotificationMessage(NotificationMesasge Request)
        {
            try
            {
                await Context.Database
                                .ExecuteSqlRawAsync($"SP_JCD_NOTIFICATION_MESSAGE_OPERATION @P_OPT_ID = 'U', " +
                                                    $"@P_NOTIFICATION_ID = {Request.NotificationId}," +
                                                    $"@P_NOTIFICATION_MSG = '{Request.NotificationMessage}'");

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
                    ErrMethod = "UpdateNotificationMessage",
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
        public async Task<CommonResponseModel> ChangeNotificationMessageStatus(byte NotificationId, byte Status)
        {
            try
            {
                await Context.Database
                                .ExecuteSqlRawAsync($"SP_JCD_NOTIFICATION_MESSAGE_OPERATION @P_OPT_ID = 'C', " +
                                                    $"@P_NOTIFICATION_ID = {NotificationId}," +
                                                    $"@P_ACTIVE_STATUS = {Status}");

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
                    ErrMethod = "UpdateNotificationMessage",
                    ErrMethodPayload = "NotificationId => " + NotificationId + ", Status => " + Status,
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
        public async Task<NotificationMsgModel> GetAllNotificationMessage() {
            try
            {
                List<NotificationMesasge> NotificationMsg = await Context.NotificationMesasge
                                                                  .FromSqlRaw($"SP_JCD_NOTIFICATION_MESSAGE_OPERATION " +
                                                                              $"@P_OPT_ID = 'O'")
                                                                  .ToListAsync();

                if (NotificationMsg.Count > 0)
                {
                    NotificationMsgModel Response = new NotificationMsgModel
                    {
                        Status = "Success",
                        NotificationMessage = NotificationMsg
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    NotificationMsgModel Response = new NotificationMsgModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "533",
                            InnerException = "",
                            Message = "No Record Found",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                NotificationMsgModel Response = new NotificationMsgModel
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
                    ErrMethod = "GetAllNotificationMessage",
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
        public async Task<NotificationMsgModel> GetActiveNotificationMessage()
        {
            try
            {
                List<NotificationMesasge> NotificationMsg = await Context.NotificationMesasge
                                                                  .FromSqlRaw($"SP_JCD_NOTIFICATION_MESSAGE_OPERATION " +
                                                                              $"@P_OPT_ID = 'A'")
                                                                  .ToListAsync();

                if (NotificationMsg.Count > 0)
                {
                    NotificationMsgModel Response = new NotificationMsgModel
                    {
                        Status = "Success",
                        NotificationMessage = NotificationMsg
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    NotificationMsgModel Response = new NotificationMsgModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "533",
                            InnerException = "",
                            Message = "No Record Found",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                NotificationMsgModel Response = new NotificationMsgModel
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
                    ErrMethod = "GetActiveNotificationMessage",
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
        public async Task<NotificationMsgModel> GetNotificationMessageById(byte NotificationId)
        {
            try
            {
                List<NotificationMesasge> NotificationMsg = await Context.NotificationMesasge
                                                                  .FromSqlRaw($"SP_JCD_NOTIFICATION_MESSAGE_OPERATION " +
                                                                              $"@P_OPT_ID = 'G', " +
                                                                              $"@P_NOTIFICATION_ID = {NotificationId}")
                                                                  .ToListAsync();

                if (NotificationMsg.Count > 0)
                {
                    NotificationMsgModel Response = new NotificationMsgModel
                    {
                        Status = "Success",
                        NotificationMessage = NotificationMsg
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    NotificationMsgModel Response = new NotificationMsgModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "533",
                            InnerException = "",
                            Message = "No Record Found",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                NotificationMsgModel Response = new NotificationMsgModel
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
                    ErrMethod = "GetNotificationMessageById",
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
    }
}
