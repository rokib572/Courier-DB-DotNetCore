using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Courier;
using Microsoft.EntityFrameworkCore;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdPickupAndDeliveryChargeRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<PickupAndDeliveryChargeResponseModel> GetPickupAndDeliveryChargeById(int ChargeId)
        {
            try
            {
                List<PickupAndDeliveryChargeInfo> ChargeInfo = await Context.PickupAndDeliveryChargeInfo
                                                                            .FromSqlRaw($"SP_JCD_PICKUP_AND_DELIVERY_CHARGE_OPERATION " +
                                                                                        $"@P_OPT_ID = 'G', @P_CHARGE_ID = {ChargeId}")
                                                                            .ToListAsync();

                if(ChargeInfo.Count > 0)
                {
                    PickupAndDeliveryChargeResponseModel Response = new PickupAndDeliveryChargeResponseModel
                    {
                        Status = "Success",
                        ChargeList = ChargeInfo
                    };

                    return await Task.FromResult(Response);
                } else
                {
                    PickupAndDeliveryChargeResponseModel Response = new PickupAndDeliveryChargeResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode ="533",
                            InnerException = "",
                            Message = "Charge not found!",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            } catch (Exception ex)
            {
                PickupAndDeliveryChargeResponseModel Response = new PickupAndDeliveryChargeResponseModel
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
                    ErrMethodPayload = "GetPickupAndDeliveryChargeById -> ChargeId = " + ChargeId,
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
        public async Task<PickupAndDeliveryChargeResponseModel> GetAllPickupAndDeliveryCharge()
        {
            try
            {
                List<PickupAndDeliveryChargeInfo> ChargeInfo = await Context.PickupAndDeliveryChargeInfo
                                                                            .FromSqlRaw($"SP_JCD_PICKUP_AND_DELIVERY_CHARGE_OPERATION " +
                                                                                        $"@P_OPT_ID = 'O'")
                                                                            .ToListAsync();

                if (ChargeInfo.Count > 0)
                {
                    PickupAndDeliveryChargeResponseModel Response = new PickupAndDeliveryChargeResponseModel
                    {
                        Status = "Success",
                        ChargeList = ChargeInfo
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    PickupAndDeliveryChargeResponseModel Response = new PickupAndDeliveryChargeResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "533",
                            InnerException = "",
                            Message = "Charge not found!",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                PickupAndDeliveryChargeResponseModel Response = new PickupAndDeliveryChargeResponseModel
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
                    ErrMethodPayload = "GetAllPickupAndDeliveryCharge",
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
        public async Task<PickupAndDeliveryChargeResponseModel> GetActivePickupAndDeliveryCharge()
        {
            try
            {
                List<PickupAndDeliveryChargeInfo> ChargeInfo = await Context.PickupAndDeliveryChargeInfo
                                                                            .FromSqlRaw($"SP_JCD_PICKUP_AND_DELIVERY_CHARGE_OPERATION " +
                                                                                        $"@P_OPT_ID = 'A'")
                                                                            .ToListAsync();

                if (ChargeInfo.Count > 0)
                {
                    PickupAndDeliveryChargeResponseModel Response = new PickupAndDeliveryChargeResponseModel
                    {
                        Status = "Success",
                        ChargeList = ChargeInfo
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    PickupAndDeliveryChargeResponseModel Response = new PickupAndDeliveryChargeResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "533",
                            InnerException = "",
                            Message = "Charge not found!",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                PickupAndDeliveryChargeResponseModel Response = new PickupAndDeliveryChargeResponseModel
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
                    ErrMethodPayload = "GetActivePickupAndDeliveryCharge",
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
        public async Task<CommonResponseModel> AddPickupAndDeliveryCharge(PickupAndDeliveryReqeustInfo ChargeModel)
        {
            try
            {
                await Context.Database
                                    .ExecuteSqlRawAsync($"SP_JCD_PICKUP_AND_DELIVERY_CHARGE_OPERATION " +
                                                        $"@P_OPT_ID = 'I', " +
                                                        $"@P_CITY_DISTRICT_ID = {ChargeModel.CityDistrictId}, " +
                                                        $"@P_PICKUP_POINT = {ChargeModel.PickupPoint}," +
                                                        $"@P_DELIVERY_POINT = {ChargeModel.DeliveryPoint}," +
                                                        $"@P_PICKUP_CHARGE = {ChargeModel.PickupCharge}," +
                                                        $"@P_DELIVERY_CHARGE = {ChargeModel.DeliveryCharge}," +
                                                        $"@P_USER_ID = {ChargeModel.UserId}");

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
                    ErrMethod = "AddPickupAndDeliveryCharge",
                    ErrMethodPayload = JsonConvert.SerializeObject(ChargeModel),
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
        public async Task<CommonResponseModel> UpdatePickupAndDeliveryCharge(PickupAndDeliveryReqeustInfo ChargeModel)
        {
            try
            {
                await Context.Database
                                    .ExecuteSqlRawAsync($"SP_JCD_PICKUP_AND_DELIVERY_CHARGE_OPERATION " +
                                                        $"@P_OPT_ID = 'U', " +
                                                        $"@P_CHARGE_ID = {ChargeModel.ChargeId}," +
                                                        $"@P_CITY_DISTRICT_ID = {ChargeModel.CityDistrictId}, " +
                                                        $"@P_PICKUP_POINT = {ChargeModel.PickupPoint}," +
                                                        $"@P_DELIVERY_POINT = {ChargeModel.DeliveryPoint}," +
                                                        $"@P_PICKUP_CHARGE = {ChargeModel.PickupCharge}," +
                                                        $"@P_DELIVERY_CHARGE = {ChargeModel.DeliveryCharge}," +
                                                        $"@P_USER_ID = {ChargeModel.UserId}");

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
                    ErrMethod = "UpdatePickupAndDeliveryCharge",
                    ErrMethodPayload = JsonConvert.SerializeObject(ChargeModel),
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
        public async Task<CommonResponseModel> UpdatePickupAndDeliveryChargeStatus(int ChargeId, byte Status, int UserId)
        {
            try
            {
                await Context.Database
                                    .ExecuteSqlRawAsync($"SP_JCD_PICKUP_AND_DELIVERY_CHARGE_OPERATION " +
                                                $"@P_OPT_ID = 'C', @P_CHARGE_ID = {ChargeId}," +
                                                $"@P_USER_ID = {UserId}," +
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "UpdatePickupAndDeliveryChargeStatus -> ChargeId = " + ChargeId + ", Status => " + Status,
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
