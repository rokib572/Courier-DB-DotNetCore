using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Microsoft.EntityFrameworkCore;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.CommonModels;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdCountryInfoRepo
    {
        JpxCourierContext _context = new JpxCourierContext();

        public async Task<CountryInfoModel> GetActiveCounties()
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {
                List<CountryInfo> CountryInfoList = await _context.CountryInfo
                                                         .FromSqlRaw($"SP_JCD_GET_ACTIVE_COUNTRIES")
                                                         .ToListAsync();

                //List<JcdCountryInfo> Countries = await _context.JcdCountryInfo.Where(x => x.ActiveStatus == 1).OrderBy(y=> y.CountryName).ToListAsync();
                CountryInfoModel CountryModel = new CountryInfoModel
                {
                    Status = "Success",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    Countries = CountryInfoList
                };
                return await Task.FromResult(CountryModel);
            } catch (Exception ex)
            {
                CountryInfoModel CountryModel = new CountryInfoModel
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
                    ErrMethodPayload = "GetActiveCountries",
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
        public async Task<CountryInfoModel> GetCountryDetails()
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {
                List<CountryDetails> CountryDetails = await _context.CountryDetails
                                                         .FromSqlRaw($"SP_JCD_GET_ADDRESS_DETAILS @OPT_ID = 1")
                                                         .ToListAsync();

                //List<JcdCountryInfo> Countries = await _context.JcdCountryInfo.Where(x => x.ActiveStatus == 1).OrderBy(y => y.CountryName).ToListAsync();
                CountryInfoModel CountryModel = new CountryInfoModel
                {
                    Status = "Success",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    CountryDetails = CountryDetails
                };
                return await Task.FromResult(CountryModel);
            }
            catch (Exception ex)
            {
                CountryInfoModel CountryModel = new CountryInfoModel
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
        public async Task<CountryInfoModel> GetCountryById (int CountryId)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {
                CountryInfo CountryInfo = await Task.FromResult(_context.CountryInfo
                                                         .FromSqlRaw($"SP_JCD_GET_ACTIVE_COUNTRIES {CountryId}")
                                                         .AsEnumerable()
                                                         .FirstOrDefault());

                //JcdCountryInfo _Country = await _context.JcdCountryInfo.Where(x => x.CountryId == CountryId).FirstOrDefaultAsync();

                if(CountryInfo != null)
                {
                    CountryInfoModel CountryModel = new CountryInfoModel
                    {
                        Status = "Success",
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                        Country = CountryInfo
                    };

                    return await Task.FromResult(CountryModel);
                } else
                {
                    CountryInfoModel CountryModel = new CountryInfoModel
                    {
                        Status = "Error",
                        ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                        Error = new ErrorModel
                        {
                            ErrorCode = "513",
                            InnerException = "",
                            Message = "Country Not Found!",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(CountryModel);
                }
            } catch (Exception ex)
            {
                CountryInfoModel CountryModel = new CountryInfoModel
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
                    ErrMethodPayload = "GetCountryById",
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
        public async Task<CommonResponseModel> AddNewCountry(CountryRequestModel RequestModel)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {
                var parameters = new[] {
                        new SqlParameter("@COUNTRY_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.CountryCode },
                        new SqlParameter("@COUNTRY_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.CountryName },
                        new SqlParameter("@TELEPHONE_CODE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.TelephoneCode },
                        new SqlParameter("@NOTES", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.Notes },
                        new SqlParameter("@ENTRY_USER", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.UserId },
                        new SqlParameter("@ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 1 },
                        new SqlParameter("@OPT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = 'I' },
                    };

                double TotalResults = await Task.FromResult(_context.Set<CountryDetails>()
                                   .FromSqlRaw("SP_JCD_COUNTRY_OPERATION @COUNTRY_ID =0, @COUNTRY_CODE=''," +
                                                " @COUNTRY_NAME='" + RequestModel.CountryName + "', @TELEPHONE_CODE='', @NOTES='', " +
                                                "@ENTRY_USER=0, @ACTIVE_STATUS = 0, @OPT_ID='N'")
                                   .AsEnumerable()
                                   .Count());

                if (TotalResults == 0)
                {
                    await _context.Database.ExecuteSqlRawAsync("SP_JCD_COUNTRY_OPERATION @COUNTRY_ID, @COUNTRY_CODE, @COUNTRY_NAME, @TELEPHONE_CODE," +
                                                                "@NOTES, @ENTRY_USER, @ACTIVE_STATUS, @OPT_ID",
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
                            Message = "A Country named " + RequestModel.CountryName + " already exists.",
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
                    ErrProcedure = "AddNewCountry",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }
        }
        public async Task<CommonResponseModel> UpdateCountry(CountryRequestModel RequestModel)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {
                var parameters = new[] {
                        new SqlParameter("@COUNTRY_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.CountryId },
                        new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.CountryCode },
                        new SqlParameter("@COUNTRY_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.CountryName },
                        new SqlParameter("@TELEPHONE_CODE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.TelephoneCode },
                        new SqlParameter("@NOTES", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestModel.Notes },
                        new SqlParameter("@ENTRY_USER", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = RequestModel.UserId },
                        new SqlParameter("@ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = RequestModel.ActiveStatus },
                        new SqlParameter("@OPT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = 'U' },
                    };

                double TotalResults = await Task.FromResult(_context.Set<CountryDetails>()
                                   .FromSqlRaw("SP_JCD_COUNTRY_OPERATION @COUNTRY_ID =" + RequestModel.CountryId + ", @COUNTRY_CODE=''," +
                                                " @COUNTRY_NAME='', @TELEPHONE_CODE='', @NOTES='', " +
                                                "@ENTRY_USER=0, @ACTIVE_STATUS = 0, @OPT_ID='G'")
                                   .AsEnumerable()
                                   .Count());

                if (TotalResults > 0)
                {                   
                    await _context.Database.ExecuteSqlRawAsync("SP_JCD_COUNTRY_OPERATION @COUNTRY_ID, @COUNTRY_CODE, @COUNTRY_NAME, @TELEPHONE_CODE," +
                                                                "@NOTES, @ENTRY_USER, @ACTIVE_STATUS, @OPT_ID",
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
                            Message = "Country ID " + RequestModel.CountryId + " not found.",
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
                    ErrProcedure = "UpdateCountry",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }
        }
        public async Task<CommonResponseModel> ChangeCountryStatus(int CountryId, byte Status, int UserId)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {
                var parameters = new[] {
                        new SqlParameter("@COUNTRY_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = CountryId },
                        new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@COUNTRY_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@TELEPHONE_CODE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@NOTES", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@ENTRY_USER", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = UserId },
                        new SqlParameter("@ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = Status },
                        new SqlParameter("@OPT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = 'C' },
                    };

                double TotalResults = await Task.FromResult(_context.Set<CountryDetails>()
                                   .FromSqlRaw("SP_JCD_COUNTRY_OPERATION @COUNTRY_ID =" + CountryId + ", @COUNTRY_CODE=''," +
                                                " @COUNTRY_NAME='', @TELEPHONE_CODE='', @NOTES='', " +
                                                "@ENTRY_USER=0, @ACTIVE_STATUS = 0, @OPT_ID='G'")
                                   .AsEnumerable()
                                   .Count());

                if (TotalResults > 0)
                {
                    await _context.Database.ExecuteSqlRawAsync("SP_JCD_COUNTRY_OPERATION @COUNTRY_ID, @COUNTRY_CODE, @COUNTRY_NAME, @TELEPHONE_CODE," +
                                                                "@NOTES, @ENTRY_USER, @ACTIVE_STATUS, @OPT_ID",
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
                            Message = "Country ID " + CountryId + " not found.",
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
                    ErrMethodPayload = "",
                    ErrProcedure = "CountryId => " + CountryId + ", Status => " + Status + ", UserId => " + UserId,
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