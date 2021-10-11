using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdDeliveryTimeSlotsRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<DeliveryTimeSlotsResponseModel> GetActiveDeliveryTimeSlot()
        {
            try
            {
                List<DeliveryTimeSlotsInfo> DeliveryTimeSlots = await Context.DeliveryTimeSlotsInfo
                                                                  .FromSqlRaw($"SP_JCD_DELIVERY_TIME_SLOTS_OPERATION @P_OPT_ID = 'A'")
                                                                  .ToListAsync();

                if (DeliveryTimeSlots.Count > 0)
                {
                    DeliveryTimeSlotsResponseModel Response = new DeliveryTimeSlotsResponseModel
                    {
                        Status = "Success",
                        DeliveryTimeSlots = DeliveryTimeSlots
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    DeliveryTimeSlotsResponseModel Response = new DeliveryTimeSlotsResponseModel
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
            } catch (Exception ex)
            {
                DeliveryTimeSlotsResponseModel Response = new DeliveryTimeSlotsResponseModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "GetActiveDeliverySlot",
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
        public async Task<DeliveryTimeSlotsResponseModel> GetAllDeliveryTimeSlot()
        {
            try
            {
                List<DeliveryTimeSlotsInfo> DeliveryTimeSlots = await Context.DeliveryTimeSlotsInfo
                                                                  .FromSqlRaw($"SP_JCD_DELIVERY_TIME_SLOTS_OPERATION @P_OPT_ID = 'O'")
                                                                  .ToListAsync();

                if (DeliveryTimeSlots.Count > 0)
                {
                    DeliveryTimeSlotsResponseModel Response = new DeliveryTimeSlotsResponseModel
                    {
                        Status = "Success",
                        DeliveryTimeSlots = DeliveryTimeSlots
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    DeliveryTimeSlotsResponseModel Response = new DeliveryTimeSlotsResponseModel
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
                DeliveryTimeSlotsResponseModel Response = new DeliveryTimeSlotsResponseModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "GetAllDeliveryTimeSlot",
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
        public async Task<DeliveryTimeSlotsResponseModel> GetDeliveryTimeSlotById(int DeliveryTimeSlotId)
        {
            try
            {
                List<DeliveryTimeSlotsInfo> DeliveryTimeSlots = await Context.DeliveryTimeSlotsInfo
                                                                  .FromSqlRaw($"SP_JCD_DELIVERY_TIME_SLOTS_OPERATION @P_OPT_ID = 'G', " +
                                                                              $"@P_DELIVERY_SLOTS_ID = {DeliveryTimeSlotId}")
                                                                  .ToListAsync();

                if (DeliveryTimeSlots.Count > 0)
                {
                    DeliveryTimeSlotsResponseModel Response = new DeliveryTimeSlotsResponseModel
                    {
                        Status = "Success",
                        DeliveryTimeSlots = DeliveryTimeSlots
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    DeliveryTimeSlotsResponseModel Response = new DeliveryTimeSlotsResponseModel
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
                DeliveryTimeSlotsResponseModel Response = new DeliveryTimeSlotsResponseModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "GetDeliveryTimeSlotById",
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
        public async Task<CommonResponseModel> AddDeliveryTimeSlot(DeliveryTimeSlotsRequest DeliveryTimeSlot)
        {
            try
            {
                await Context.Database
                                    .ExecuteSqlRawAsync($"SP_JCD_DELIVERY_TIME_SLOTS_OPERATION @P_OPT_ID = 'I', " +
                                                $"@P_DELIVERY_TYPE = '{DeliveryTimeSlot.DeliveryType}'," +
                                                $"@P_DISCLAIMER = '{DeliveryTimeSlot.Disclaimer}'," +
                                                $"@P_DELIVERY_TIME = '{DeliveryTimeSlot.DeliveryTime}'," +
                                                $"@P_REQUEST_BEFORE = '{DeliveryTimeSlot.RequestBefore}'," +
                                                $"@P_DESTINATION_TYPE = '{DeliveryTimeSlot.DestinationType}'," +
                                                $"@P_DESTINATION_CHARGE = '{DeliveryTimeSlot.DestinationCharge}'," +
                                                $"@P_USER_ID = {DeliveryTimeSlot.UserId}");

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
                    ErrMethod = "AddDeliveryTimeSlot",
                    ErrMethodPayload = JsonConvert.SerializeObject(DeliveryTimeSlot),
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
        public async Task<CommonResponseModel> UpdateDeliveryTimeSlot(DeliveryTimeSlotsRequest DeliveryTimeSlot)
        {
            try
            {
                await Context.Database
                                    .ExecuteSqlRawAsync($"SP_JCD_DELIVERY_TIME_SLOTS_OPERATION @P_OPT_ID = 'U', " +
                                                $"@P_DELIVERY_TYPE = '{DeliveryTimeSlot.DeliveryType}'," +
                                                $"@P_DESTINATION_ID = {DeliveryTimeSlot.DestinationId}," +
                                                $"@P_DISCLAIMER = '{DeliveryTimeSlot.Disclaimer}'," +
                                                $"@P_DELIVERY_TIME = '{DeliveryTimeSlot.DeliveryTime}'," +
                                                $"@P_REQUEST_BEFORE = '{DeliveryTimeSlot.RequestBefore}'," +
                                                $"@P_DESTINATION_TYPE = '{DeliveryTimeSlot.DestinationType}'," +
                                                $"@P_DESTINATION_CHARGE = '{DeliveryTimeSlot.DestinationCharge}'," +
                                                $"@P_USER_ID = {DeliveryTimeSlot.UserId}," +
                                                $"@P_DELIVERY_SLOTS_ID = {DeliveryTimeSlot.DeliverySlotsId}");

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
                    ErrMethod = "UpdateDeliveryTimeSlot",
                    ErrMethodPayload = JsonConvert.SerializeObject(DeliveryTimeSlot),
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
        public async Task<CommonResponseModel> ChangeDeliveryTimeSlotStatus(int DeliveryTimeSlotId, int DestinationId, byte Status, int UserId)
        {
            try
            {
                await Context.Database
                                    .ExecuteSqlRawAsync($"SP_JCD_DELIVERY_TIME_SLOTS_OPERATION @P_OPT_ID = 'C', " +
                                                $"@P_ACTIVE_STATUS = {Status}," +
                                                $"@P_DELIVERY_SLOTS_ID = {DeliveryTimeSlotId}," +
                                                $"@P_DESTINATION_ID = {DestinationId}," +
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
                    ErrMethod = "ChangeDeliveryTimeSlotStatus",
                    ErrMethodPayload = "DeliveryTimeSlotId => " + DeliveryTimeSlotId + ", Status => " + Status + ", UserId => " + UserId,
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
