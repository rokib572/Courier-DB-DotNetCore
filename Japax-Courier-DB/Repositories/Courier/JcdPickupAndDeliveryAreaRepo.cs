using Japax_Courier_DB.DBModels.CommonModels;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdPickupAndDeliveryAreaRepo
    {
        JpxCourierContext _context = new JpxCourierContext();

        public async Task<PickupAndDeliveryAreaModel> GetActiveAreas()
        {
            try
            {
                List<AreaInfo> Result = await Task.FromResult(_context.Set<AreaInfo>()
                                                         .FromSqlRaw("SP_JCD_GET_AREA @ID =1, @OPT_ID = 3")
                                                         .AsEnumerable()
                                                         .ToList());

                PickupAndDeliveryAreaModel _AreaModel = new PickupAndDeliveryAreaModel
                {
                    Status = "Success",
                    Areas = Result
                };
                return await Task.FromResult(_AreaModel);
            }
            catch (Exception ex)
            {
                PickupAndDeliveryAreaModel _AreaModel = new PickupAndDeliveryAreaModel
                {
                    Status = "Success",
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
                    ErrMethodPayload = "GetActiveAreas",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_AreaModel);
            }
        }
        public async Task<PickupAndDeliveryAreaModel> GetAreaById(int AreaId)
        {
            try
            {
                AreaInfo Result = await Task.FromResult(_context.Set<AreaInfo>()
                                                         .FromSqlRaw("SP_JCD_GET_AREA @ID =" + AreaId + ", @OPT_ID = 1")
                                                         .AsEnumerable()
                                                         .FirstOrDefault());

                PickupAndDeliveryAreaModel _AreaModel = new PickupAndDeliveryAreaModel
                {
                    Area = Result,
                    Status = "Success"
                };
                return await Task.FromResult(_AreaModel);
            }
            catch (Exception ex)
            {
                PickupAndDeliveryAreaModel _AreaModel = new PickupAndDeliveryAreaModel
                {
                    Status = "error",
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
                    ErrMethodPayload = "GetAreaById",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_AreaModel);
            }
        }
        public async Task<PickupAndDeliveryAreaModel> GetAreaByPsUpazilaId(int PsUpazilaId)
        {
            try
            {
                List<AreaInfo> Result = await Task.FromResult(_context.Set<AreaInfo>()
                                                         .FromSqlRaw("SP_JCD_GET_AREA @ID =" + PsUpazilaId + ", @OPT_ID = 2")
                                                         .AsEnumerable()
                                                         .ToList());

                PickupAndDeliveryAreaModel _AreaModel = new PickupAndDeliveryAreaModel
                {
                    Status = "Success",
                    Areas = Result
                };
                return await Task.FromResult(_AreaModel);
            }
            catch (Exception ex)
            {
                PickupAndDeliveryAreaModel _AreaModel = new PickupAndDeliveryAreaModel
                {
                    Status = "Success",
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
                    ErrMethodPayload = "GetActiveAreas",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_AreaModel);
            }
        }
        public async Task<PickupAndDeliveryAreaModel> GetAreaByCityDistrictId(int CityDistrictId)
        {
            try
            {
                List<AreaInfo> Result = await Task.FromResult(_context.Set<AreaInfo>()
                                                         .FromSqlRaw("SP_JCD_GET_AREA @ID =" + CityDistrictId + ", @OPT_ID = 4")
                                                         .AsEnumerable()
                                                         .ToList());

                PickupAndDeliveryAreaModel _AreaModel = new PickupAndDeliveryAreaModel
                {
                    Status = "Success",
                    Areas = Result
                };
                return await Task.FromResult(_AreaModel);
            }
            catch (Exception ex)
            {
                PickupAndDeliveryAreaModel _AreaModel = new PickupAndDeliveryAreaModel
                {
                    Status = "Success",
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
                    ErrMethodPayload = "GetActiveAreas",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_AreaModel);
            }
        }
        public async Task<CommonResponseModel> AddNewArea(AreaRequestModel RequestModel)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {
                double TotalResults = await Task.FromResult(_context.Set<AreaInfo>()
                                   .FromSqlRaw("SP_JCD_GET_AREA @AREA_NAME ='" + RequestModel.AreaName + "', @OPT_ID=5")
                                   .AsEnumerable()
                                   .Count());

                if (TotalResults == 0)
                {
                    var parameters = new[] {
                        new SqlParameter("@AREA_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@AREA_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.AreaName },
                        new SqlParameter("@PS_UPAZLA_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.PsUpazilaId },
                        new SqlParameter("@ZONE_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.ZoneId },
                        new SqlParameter("@POLYGON", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.AreaPolygon },
                        new SqlParameter("@USER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.UserId },
                        new SqlParameter("@ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@OPT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = 'I' },
                    };

                    await _context.Database.ExecuteSqlRawAsync("SP_JCD_AREA_OPERATION @AREA_ID, @AREA_NAME, @PS_UPAZLA_ID, @ZONE_ID," +
                                                                "@POLYGON, @USER_ID, @ACTIVE_STATUS, @OPT_ID",
                                                                parameters);

                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Success",
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms"
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Error",
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                        Error = new ErrorModel
                        {
                            ErrorCode = "523",
                            InnerException = "",
                            Message = "A Area named " + RequestModel.AreaName + " already exists.",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
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
                    ErrMethodPayload = JsonConvert.SerializeObject(RequestModel),
                    ErrProcedure = "AddNewArea",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Response);
            }
        }
        public async Task<CommonResponseModel> UpdateAreaStatus(AreaRequestModel RequestModel)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {
                double TotalResults = await Task.FromResult(_context.Set<AreaInfo>()
                                   .FromSqlRaw("SP_JCD_GET_AREA @ID =" + RequestModel.AreaId + ", @OPT_ID=1")
                                   .AsEnumerable()
                                   .Count());

                if (TotalResults > 0)
                {
                    var parameters = new[] {
                        new SqlParameter("@AREA_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.AreaId },
                        new SqlParameter("@AREA_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.AreaName },
                        new SqlParameter("@PS_UPAZLA_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.PsUpazilaId },
                        new SqlParameter("@ZONE_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.ZoneId },
                        new SqlParameter("@POLYGON", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.AreaPolygon },
                        new SqlParameter("@USER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.UserId },
                        new SqlParameter("@ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = RequestModel.ActiveStatus },
                        new SqlParameter("@OPT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = 'U' },
                    };

                    await _context.Database.ExecuteSqlRawAsync("SP_JCD_AREA_OPERATION @AREA_ID, @AREA_NAME, @PS_UPAZLA_ID, @ZONE_ID," +
                                                                "@POLYGON, @USER_ID, @ACTIVE_STATUS, @OPT_ID",
                                                                parameters);

                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Success",
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms"
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Error",
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                        Error = new ErrorModel
                        {
                            ErrorCode = "523",
                            InnerException = "",
                            Message = "Area named " + RequestModel.AreaName + " not found.",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
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
                    ErrMethodPayload = JsonConvert.SerializeObject(RequestModel),
                    ErrProcedure = "AddNewArea",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Response);
            }
        }
        public async Task<PickupAndDeliveryAreaModel> GetAreaDetails()
        {
            try
            {
                List<AreaDetails> AreaDetails = await _context.AreaDetails
                                                         .FromSqlRaw($"SP_JCD_GET_ADDRESS_DETAILS @OPT_ID = 5")
                                                         .ToListAsync();

                //List<JcdCountryInfo> Countries = await _context.JcdCountryInfo.Where(x => x.ActiveStatus == 1).OrderBy(y => y.CountryName).ToListAsync();
                PickupAndDeliveryAreaModel Response = new PickupAndDeliveryAreaModel
                {
                    Status = "Success",
                    AreaDetails = AreaDetails
                };
                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                PickupAndDeliveryAreaModel CountryModel = new PickupAndDeliveryAreaModel
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
                    ErrMethodPayload = "GetAreaDetails",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(CountryModel);
            }
        }
    }
}
