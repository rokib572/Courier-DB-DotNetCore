using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdPickupDeliveryTimePeriodsRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<CommonResponseModel> AddTimePeriods(PickupAndDeliveryTimePeriodRequestModel Request)
        {
            try
            {
                await Context.Database
                                .ExecuteSqlRawAsync($"SP_JCD_PICKUP_DELIVERY_TIME_PERIODS_OPERATION @P_OPT_ID = 'I', " +
                                                    $"@P_START_TIME = '{Request.StartTime}'," +
                                                    $"@P_END_TIME = '{Request.EndTime}'," +
                                                    $"@P_REQUEST_BEFORE = {Request.RequestBefore}," +
                                                    $"@P_REQUEST_BEFORE_UM = '{Request.RequestBeforeUm}'");

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success",
                };

                return await Task.FromResult(Response);
            } catch (Exception ex)
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
                    ErrMethod = "AddTimePeriods",
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
        public async Task<CommonResponseModel> UpdateTimePeriods(PickupAndDeliveryTimePeriodRequestModel Request)
        {
            try
            {
                await Context.Database
                                .ExecuteSqlRawAsync($"SP_JCD_PICKUP_DELIVERY_TIME_PERIODS_OPERATION @P_OPT_ID = 'U', " +
                                                    $"@P_TIME_PERIOD_ID = {Request.TimePeriodId}," +
                                                    $"@P_START_TIME = '{Request.StartTime}'," +
                                                    $"@P_END_TIME = '{Request.EndTime}'," +
                                                    $"@P_REQUEST_BEFORE = {Request.RequestBefore}," +
                                                    $"@P_REQUEST_BEFORE_UM = '{Request.RequestBeforeUm}'");

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
                    ErrMethod = "UpdateTimePeriods",
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
        public async Task<CommonResponseModel> ChangeTimePeriodStatus (int TimePeriodId, int status)
        {
            try
            {
                await Context.Database
                                .ExecuteSqlRawAsync($"SP_JCD_PICKUP_DELIVERY_TIME_PERIODS_OPERATION @P_OPT_ID = 'C', " +
                                                    $"@P_TIME_PERIOD_ID = {TimePeriodId}," +
                                                    $"@P_STATUS = {status}");

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
                    ErrMethod = "ChangeTimePeriodStatus",
                    ErrMethodPayload = "Time Period Id => " + TimePeriodId + " | Status => " + status,
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
        public async Task<PickupAndDeliveryTimePeriodResponseModel> GetTimePeriodById (int TimePeriodId)
        {
            try
            {
                List<PickupAndDeliveryTimePeriodInfo> TimePeriodInfo = await Context.PickupAndDeliveryTimePeriodInfo.FromSqlRaw
                                                                        ($"SP_JCD_PICKUP_DELIVERY_TIME_PERIODS_OPERATION " +
                                                                         $"@P_OPT_ID = 'G'," +
                                                                         $"@P_TIME_PERIOD_ID = {TimePeriodId}")
                                                                         .ToListAsync();

                if(TimePeriodInfo != null)
                {
                    PickupAndDeliveryTimePeriodResponseModel Response = new PickupAndDeliveryTimePeriodResponseModel
                    {
                        Status = "Success",
                        TimePeriodInfo = TimePeriodInfo
                    };

                    return await Task.FromResult(Response);
                } else
                {
                    PickupAndDeliveryTimePeriodResponseModel Response = new PickupAndDeliveryTimePeriodResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "530",
                            InnerException = "",
                            Message = "No record found!",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            } catch (Exception ex)
            {
                PickupAndDeliveryTimePeriodResponseModel Response = new PickupAndDeliveryTimePeriodResponseModel
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
                    ErrMethod = "GetTimePeriodById",
                    ErrMethodPayload = "Time Period Id => " + TimePeriodId,
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
        public async Task<PickupAndDeliveryTimePeriodResponseModel> GetActiveTimePeriod()
        {
            try
            {
                List<PickupAndDeliveryTimePeriodInfo> TimePeriodInfo = await Context.PickupAndDeliveryTimePeriodInfo.FromSqlRaw
                                                                        ($"SP_JCD_PICKUP_DELIVERY_TIME_PERIODS_OPERATION " +
                                                                         $"@P_OPT_ID = 'A'")
                                                                         .ToListAsync();

                if (TimePeriodInfo != null)
                {
                    PickupAndDeliveryTimePeriodResponseModel Response = new PickupAndDeliveryTimePeriodResponseModel
                    {
                        Status = "Success",
                        TimePeriodInfo = TimePeriodInfo
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    PickupAndDeliveryTimePeriodResponseModel Response = new PickupAndDeliveryTimePeriodResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "530",
                            InnerException = "",
                            Message = "No record found!",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                PickupAndDeliveryTimePeriodResponseModel Response = new PickupAndDeliveryTimePeriodResponseModel
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
                    ErrMethod = "GetActiveTimePeriod",
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
        public async Task<PickupAndDeliveryTimePeriodResponseModel> GetAllTimePeriod()
        {
            try
            {
                List<PickupAndDeliveryTimePeriodInfo> TimePeriodInfo = await Context.PickupAndDeliveryTimePeriodInfo.FromSqlRaw
                                                                        ($"SP_JCD_PICKUP_DELIVERY_TIME_PERIODS_OPERATION " +
                                                                         $"@P_OPT_ID = 'O'")
                                                                         .ToListAsync();

                if (TimePeriodInfo != null)
                {
                    PickupAndDeliveryTimePeriodResponseModel Response = new PickupAndDeliveryTimePeriodResponseModel
                    {
                        Status = "Success",
                        TimePeriodInfo = TimePeriodInfo
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    PickupAndDeliveryTimePeriodResponseModel Response = new PickupAndDeliveryTimePeriodResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "530",
                            InnerException = "",
                            Message = "No record found!",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                PickupAndDeliveryTimePeriodResponseModel Response = new PickupAndDeliveryTimePeriodResponseModel
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
                    ErrMethod = "GetAllTimePeriod",
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
    }
}
