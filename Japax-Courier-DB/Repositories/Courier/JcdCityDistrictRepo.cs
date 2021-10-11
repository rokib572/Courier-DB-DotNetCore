using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdCityDistrictRepo
    {
        JpxCourierContext _context = new JpxCourierContext();

        public async Task<CityDistrictModel> GetActiveCities()
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {
                List<CityDistrictInfo> Cities = await _context.CityDistrictInfo
                                                         .FromSqlRaw("SP_JCD_GET_CITY_DISTRICT @OPT_ID = 1")
                                                         .ToListAsync();

                //List<JcdCityDistrict> Cities = await _context.JcdCityDistrict.Where(x => x.ActiveStatus == 1).OrderBy(y=> y.CityDistrictName).ToListAsync();
                CityDistrictModel _CityDistrictModel = new CityDistrictModel
                {
                    Status = "Success",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    Cities = Cities
                };
                return await Task.FromResult(_CityDistrictModel);
            } catch(Exception ex)
            {
                CityDistrictModel _CityDistrictModel = new CityDistrictModel
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
                    ErrMethodPayload = "GetActiveCities",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }
        }
        public async Task<CityDistrictModel> GetCityById(int CityId)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {
                CityDistrictInfo City = await Task.FromResult(_context.CityDistrictInfo
                                                         .FromSqlRaw("SP_JCD_GET_CITY_DISTRICT @ID =" + CityId + ", @OPT_ID = 2")
                                                         .AsEnumerable()
                                                         .FirstOrDefault());

                //JcdCityDistrict _City = await _context.JcdCityDistrict.Where(x => x.CityDistrictId == CityId).FirstOrDefaultAsync();

                if(City != null)
                {
                    CityDistrictModel _CityModel = new CityDistrictModel
                    {
                        Status = "Success",
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                        City = City
                    };

                    return await Task.FromResult(_CityModel);
                } else
                {
                    CityDistrictModel _CityDistrictModel = new CityDistrictModel
                    {
                        Status = "Error",
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                        Error = new ErrorModel
                        {
                            ErrorCode = "513",
                            InnerException = "",
                            Message = "City or District not found.",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(_CityDistrictModel);
                }
                
            } catch (Exception ex)
            {
                CityDistrictModel _CityDistrictModel = new CityDistrictModel
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
                    ErrMethodPayload = "GetCityById",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }
        }
        public async Task<CityDistrictModel> GetCityByState(int StateId)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {
                List<CityDistrictInfo> Cities = await _context.CityDistrictInfo
                                                         .FromSqlRaw("SP_JCD_GET_CITY_DISTRICT @ID =" + StateId + ", @OPT_ID = 3")
                                                         .ToListAsync();

                //List<JcdCityDistrict> Cities = await _context.JcdCityDistrict.Where(x => x.ProvinceId == StateId && x.ActiveStatus == 1).OrderBy(y => y.CityDistrictName).ToListAsync();
                CityDistrictModel _CityDistrictModel = new CityDistrictModel
                {
                    Status = "Success",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    Cities = Cities
                };
                return await Task.FromResult(_CityDistrictModel);
            }
            catch (Exception ex)
            {
                CityDistrictModel _CityDistrictModel = new CityDistrictModel
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
                    ErrMethodPayload = "GetActiveCities",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }
        }
        public async Task<CityDistrictModel> GetCityDetails() {
            try
            {
                List<CityDistrictDetails> CityDetails = await _context.CityDistrictDetails
                                                         .FromSqlRaw($"SP_JCD_GET_ADDRESS_DETAILS @OPT_ID = 3")
                                                         .ToListAsync();

                //List<JcdCountryInfo> Countries = await _context.JcdCountryInfo.Where(x => x.ActiveStatus == 1).OrderBy(y => y.CountryName).ToListAsync();
                CityDistrictModel Response = new CityDistrictModel
                {
                    Status = "Success",
                    CityDistrictDetails = CityDetails
                };
                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                CityDistrictModel CountryModel = new CityDistrictModel
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
                    ErrMethodPayload = "GetCountryDetails",
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
        public async Task<CommonResponseModel> AddNewCity(CityDistrictRequestModel RequestModel)
        {
            try
            {
                int CityId = await Task.FromResult(_context.CityDistrictInfo
                                                    .FromSqlRaw($"SP_JCD_GET_CITY_DISTRICT @CityName = '" + RequestModel.CityDistrictName + "', @OPT_ID = 4")
                                                    .AsEnumerable()
                                                    .Count());
                //var checkCity = await _context.JcdCityDistrict.Where(x => x.CityDistrictName == RequestModel.CityDistrictName && x.ProvinceId == RequestModel.ProvinceId).FirstOrDefaultAsync();
                if(CityId == 0)
                {
                    var parameters = new[] {
                        new SqlParameter("@P_CITY_DISTRICT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.CityDistrictId },
                        new SqlParameter("@P_CITY_DISTRICT_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.CityDistrictName },
                        new SqlParameter("@P_PROVINCE_ID", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = RequestModel.ProvinceId },
                        new SqlParameter("@P_ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 1},
                        new SqlParameter("@P_USER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.UserId},
                        new SqlParameter("@P_OPT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "I"}
                    };

                    await _context.Database.ExecuteSqlRawAsync($"SP_JCD_CITY_DISTRICT @P_CITY_DISTRICT_ID, " +
                                                               $"@P_CITY_DISTRICT_NAME, @P_PROVINCE_ID, @P_ACTIVE_STATUS, @P_USER_ID, " +
                                                               $"@P_OPT", parameters);

                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Success"
                    };

                    return await Task.FromResult(Response);                    
                } else
                {
                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status ="Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "523",
                            InnerException = "",
                            Message = "A City named " + RequestModel.CityDistrictName + " already exists.",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }                
            }
            catch (Exception ex)
            {
                CommonResponseModel _CityDistrictModel = new CommonResponseModel
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
                    ErrMethodPayload = JsonConvert.SerializeObject(RequestModel),
                    ErrProcedure = "AddNewCity",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }            
        }
        public async Task<CommonResponseModel> UpdateCity(CityDistrictRequestModel RequestModel)
        {
            try
            {
                int CityId = await Task.FromResult(_context.CityDistrictInfo
                                                    .FromSqlRaw($"SP_JCD_GET_CITY_DISTRICT @ID = '" + RequestModel.CityDistrictId + "', @OPT_ID = 2")
                                                    .AsEnumerable()
                                                    .Count());
                if(CityId > 0)
                {
                    var parameters = new[] {
                        new SqlParameter("@P_CITY_DISTRICT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.CityDistrictId },
                        new SqlParameter("@P_CITY_DISTRICT_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.CityDistrictName },
                        new SqlParameter("@P_PROVINCE_ID", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = RequestModel.ProvinceId },
                        new SqlParameter("@P_ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 1},
                        new SqlParameter("@P_USER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.UserId},
                        new SqlParameter("@P_OPT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "U"}
                    };

                    await _context.Database.ExecuteSqlRawAsync($"SP_JCD_CITY_DISTRICT @P_CITY_DISTRICT_ID, " +
                                                               $"@P_CITY_DISTRICT_NAME, @P_PROVINCE_ID, @P_ACTIVE_STATUS, @P_USER_ID, " +
                                                               $"@P_OPT", parameters);

                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Success"
                    };

                    return await Task.FromResult(Response);
                } else
                {
                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "523",
                            InnerException = "",
                            Message ="City or District name not found!",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            } catch (Exception ex)
            {
                CommonResponseModel _CityDistrictModel = new CommonResponseModel
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
                    ErrMethodPayload = JsonConvert.SerializeObject(RequestModel),
                    ErrProcedure = "UpdateCity",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }
        }
        public async Task<CommonResponseModel> ChangeCityStatus(int CityDistrictId, byte Status, int UserId)
        {
            try
            {
                int CityId = await Task.FromResult(_context.CityDistrictInfo
                                                    .FromSqlRaw($"SP_JCD_GET_CITY_DISTRICT @ID = '" + CityDistrictId + "', @OPT_ID = 2")
                                                    .AsEnumerable()
                                                    .Count());
                if (CityId > 0)
                {
                    var parameters = new[] {
                        new SqlParameter("@P_CITY_DISTRICT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = CityDistrictId },
                        new SqlParameter("@P_CITY_DISTRICT_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@P_PROVINCE_ID", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@P_ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = Status},
                        new SqlParameter("@P_USER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = UserId},
                        new SqlParameter("@P_OPT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "C"}
                    };

                    await _context.Database.ExecuteSqlRawAsync($"SP_JCD_CITY_DISTRICT @P_CITY_DISTRICT_ID, " +
                                                               $"@P_CITY_DISTRICT_NAME, @P_PROVINCE_ID, @P_ACTIVE_STATUS, @P_USER_ID, " +
                                                               $"@P_OPT", parameters);

                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Success"
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "523",
                            InnerException = "",
                            Message = "City or District name not found!",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                CommonResponseModel _CityDistrictModel = new CommonResponseModel
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
                    ErrMethodPayload = "CityDistrictId => " + CityDistrictId + ", Status => " + Status + ", UserId => " + UserId,
                    ErrProcedure = "ChangeCityStatus",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }
        }
    }
}
