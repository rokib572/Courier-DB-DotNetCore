using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdAtcPickupAndDeliveryPointRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<AtcPointModel> GetAtcOutletsByArea(int AreaId)
        {
            try
            {

                List<AtcPoints> AtcPoints = await Context.AtcPoints
                                                        .FromSqlRaw($"SP_JCD_PICKUP_AND_DELIVERY_POINT_OPERATION @P_OPT_ID = 'D', " +
                                                                    $"@P_ATC_POINT_AREA_ID = {AreaId}")
                                                        .ToListAsync();

                AtcPointModel Response = new AtcPointModel
                {
                    Status = "Success",
                    AtcPointList = AtcPoints
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                AtcPointModel Response = new AtcPointModel
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
                    ErrMethod = "GetAtcOutletsByArea",
                    ErrMethodPayload = "AreaId = > " + AreaId,
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
        public async Task<AtcPointModel> GetAtcOutletById (int PointId)
        {
            try
            {

                List<AtcPoints> AtcPoints = await Context.AtcPoints
                                                        .FromSqlRaw($"SP_JCD_PICKUP_AND_DELIVERY_POINT_OPERATION @P_OPT_ID = 'G', " +
                                                                    $"@P_ATC_POINT_ID = {PointId}")
                                                        .ToListAsync();

                AtcPointModel Response = new AtcPointModel
                {
                    Status = "Success",
                    AtcPointList = AtcPoints
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                AtcPointModel Response = new AtcPointModel
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
                    ErrMethod = "GetAtcOutletById",
                    ErrMethodPayload = "Point Id = > " + PointId,
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
        public async Task<AtcPointModel> GetActiveAtcOutlet()
        {
            try
            {

                List<AtcPoints> AtcPoints = await Context.AtcPoints
                                                        .FromSqlRaw($"SP_JCD_PICKUP_AND_DELIVERY_POINT_OPERATION @P_OPT_ID = 'A'")
                                                        .ToListAsync();

                AtcPointModel Response = new AtcPointModel
                {
                    Status = "Success",
                    AtcPointList = AtcPoints
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                AtcPointModel Response = new AtcPointModel
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
                    ErrMethod = "GetActiveAtcOutlet",
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
        public async Task<AtcPointModel> GetAllAtcOutlet()
        {
            try
            {

                List<AtcPoints> AtcPoints = await Context.AtcPoints
                                                        .FromSqlRaw($"SP_JCD_PICKUP_AND_DELIVERY_POINT_OPERATION @P_OPT_ID = 'O'")
                                                        .ToListAsync();

                AtcPointModel Response = new AtcPointModel
                {
                    Status = "Success",
                    AtcPointList = AtcPoints
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                AtcPointModel Response = new AtcPointModel
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
                    ErrMethod = "GetActiveAtcOutlet",
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
        public async Task<CommonResponseModel> AddOutlet(AtcPointRequestModel Request)
        {
            try
            {
                await Context.Database
                               .ExecuteSqlRawAsync($"SP_JCD_PICKUP_AND_DELIVERY_POINT_OPERATION @P_OPT_ID = 'I', " +
                                           $"@P_ATC_POINT_NAME = '{Request.PointName}', " +
                                           $"@P_ATC_POINT_TYPE = {Request.PointType}," +
                                           $"@P_ATC_POINT_AREA_ID = {Request.AreaId}," +
                                           $"@P_ATC_POINT_ADDRESS = '{Request.Address}'," +
                                           $"@P_HOUSE_OR_ROAD_NO = '{Request.HouseOrRoadNo}'," +
                                           $"@P_ATC_POINT_STREET = '{Request.StreetAddress}'," +
                                           $"@P_ATC_POINT_POSTAL_CODE = '{Request.PostalCode}'," +
                                           $"@P_ATC_POINT_LANDMARK = '{Request.Landmark}'," +
                                           $"@P_ATC_POINT_LATITUDES_DATA = {Request.Latitudes}," +
                                           $"@P_ATC_POINT_LONGITUDES_DATA = {Request.Longitudes}," +
                                           $"@P_ATC_POINT_GEOCODING_STATUS = 1," +
                                           $"@P_ATC_POINT_MOBILE_NO = '{Request.ContactNo}'," +
                                           $"@P_USER_ID = {Request.UserId}");

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success"
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
                    ErrMethod = "AddOutlet",
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
        public async Task<CommonResponseModel> UpdateOutlet(AtcPointRequestModel Request)
        {
            try
            {
                await Context.Database
                               .ExecuteSqlRawAsync($"SP_JCD_PICKUP_AND_DELIVERY_POINT_OPERATION @P_OPT_ID = 'U'," +
                                                   $"@P_ATC_POINT_ID = {Request.PointId}," +
                                                   $"@P_ATC_POINT_NAME = '{Request.PointName}', " +
                                                   $"@P_ATC_POINT_TYPE = {Request.PointType}," +
                                                   $"@P_ATC_POINT_AREA_ID = {Request.AreaId}," +
                                                   $"@P_ATC_POINT_ADDRESS = '{Request.Address}'," +
                                                   $"@P_HOUSE_OR_ROAD_NO = '{Request.HouseOrRoadNo}'," +
                                                   $"@P_ATC_POINT_STREET = '{Request.StreetAddress}'," +
                                                   $"@P_ATC_POINT_POSTAL_CODE = '{Request.PostalCode}'," +
                                                   $"@P_ATC_POINT_LANDMARK = '{Request.Landmark}'," +
                                                   $"@P_ATC_POINT_LATITUDES_DATA = {Request.Latitudes}," +
                                                   $"@P_ATC_POINT_LONGITUDES_DATA = {Request.Longitudes}," +
                                                   $"@P_ATC_POINT_GEOCODING_STATUS = 1," +
                                                   $"@P_ATC_POINT_MOBILE_NO = '{Request.ContactNo}'," +
                                                   $"@P_USER_ID = {Request.UserId}");

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success"
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
                    ErrMethod = "UpdateOutlet",
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
        public async Task<CommonResponseModel> ChangeOutletStatus(int OutletId, byte Status, int UserId)
        {
            try
            {
                await Context.Database
                               .ExecuteSqlRawAsync($"SP_JCD_PICKUP_AND_DELIVERY_POINT_OPERATION @P_OPT_ID = 'C'," +
                                                   $"@P_ATC_POINT_ID = {OutletId}," +
                                                   $"@P_ACTIVE_STATUS = {Status}, " +
                                                   $"@P_USER_ID = {UserId}");

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success"
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
                    ErrMethod = "ChangeOutletStatus",
                    ErrMethodPayload = "OutletId => " + OutletId + ", Status => " + Status,
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
