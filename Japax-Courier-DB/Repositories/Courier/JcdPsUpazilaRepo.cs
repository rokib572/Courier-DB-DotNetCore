using Japax_Courier_DB.DBModels.CommonModels;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdPsUpazilaRepo
    {
        JpxCourierContext _context = new JpxCourierContext();

        public async Task<UpazillaModel> GetActiveUpazilla()
        {
            try
            {
                List<JcdPsUpazila> _Upazillas = await _context.JcdPsUpazila.Where(x => x.ActiveStatus == 1).OrderBy(y=> y.PsUpazlaName).ToListAsync();

                UpazillaModel _UpazillaModel = new UpazillaModel
                {
                    Status = "Success",
                    Upazillas = (from JcdPsUpazila _Upazilla in _Upazillas
                                 select new UpazillaInfo
                                 {
                                     CityDistrictId = _Upazilla.CityDistrictId,
                                     PsUpazilaId = _Upazilla.PsUpazlaId,
                                     PsUpazilaName = _Upazilla.PsUpazlaName,
                                     UnderCityCorporation = _Upazilla.UnderCityCorporation
                                 }).ToList()
                };

                return await Task.FromResult(_UpazillaModel);
            } catch (Exception ex)
            {
                UpazillaModel _UpazillaModel = new UpazillaModel
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
                    ErrMethodPayload = "GetActiveStates",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_UpazillaModel);
            }
        }
        public async Task<UpazillaModel> GetUpazillaById (int UpazillaId)
        {
            try
            {
                JcdPsUpazila _PSUpazilla = await _context.JcdPsUpazila.Where(x => x.PsUpazlaId == UpazillaId).FirstOrDefaultAsync();

                UpazillaModel _UpazillaModel = new UpazillaModel
                {
                    Status = "Success",
                    Upazilla = new UpazillaInfo
                    {
                        CityDistrictId = _PSUpazilla.CityDistrictId,
                        PsUpazilaId = _PSUpazilla.PsUpazlaId,
                        PsUpazilaName = _PSUpazilla.PsUpazlaName,
                        UnderCityCorporation = _PSUpazilla.UnderCityCorporation
                    }
                };

                return await Task.FromResult(_UpazillaModel);
            } catch (Exception ex)
            {
                UpazillaModel _UpazillaModel = new UpazillaModel
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
                    ErrMethodPayload = "GetUpazillaById",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_UpazillaModel);
            }
        }
        public async Task<UpazillaModel> GetPsUpazilaByDistrict(int CityDistrictId)
        {
            try
            {
                List<JcdPsUpazila> _Upazillas = await _context.JcdPsUpazila.Where(x => x.CityDistrictId == CityDistrictId && x.ActiveStatus == 1).OrderBy(y => y.PsUpazlaName).ToListAsync();

                UpazillaModel _UpazillaModel = new UpazillaModel
                {
                    Status = "Success",
                    Upazillas = (from JcdPsUpazila _Upazilla in _Upazillas
                                 select new UpazillaInfo
                                 {
                                     CityDistrictId = _Upazilla.CityDistrictId,
                                     PsUpazilaId = _Upazilla.PsUpazlaId,
                                     PsUpazilaName = _Upazilla.PsUpazlaName,
                                     UnderCityCorporation = _Upazilla.UnderCityCorporation
                                 }).ToList()
                };

                return await Task.FromResult(_UpazillaModel);
            }
            catch (Exception ex)
            {
                UpazillaModel _UpazillaModel = new UpazillaModel
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
                    ErrMethodPayload = "GetActiveStates",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_UpazillaModel);
            }
        }
        public async Task<CommonResponseModel> AddNewPsUpazila (PsUpazilaRequestModel RequestModel)
        {
            try
            {
                int UpazilaCount = await Task.FromResult(_context.JcdPsUpazila
                                                               .FromSqlRaw($"SP_JCD_PS_OR_UPAZILA " +
                                                                           $"@P_PS_UPAZLA_NAME = '{ RequestModel.PsUpazilaName}', " +
                                                                           $"@P_OPT = 'N'")
                                                               .AsEnumerable()
                                                               .Count());

                //var checkUpazila = await _context.JcdPsUpazila.Where(x => x.PsUpazlaName == RequestModel.PsUpazilaName && x.CityDistrictId == RequestModel.CityDistrictId).FirstOrDefaultAsync();
                if (UpazilaCount == 0)
                {
                    await _context.Database.ExecuteSqlRawAsync($"SP_JCD_PS_OR_UPAZILA @P_PS_UPAZLA_NAME = '{RequestModel.PsUpazilaName}', " +
                                                               $"@P_CITY_DISTRICT_ID = {RequestModel.CityDistrictId}, @P_ACTIVE_STATUS = 1, " +
                                                               $"@P_UNDER_CITY_CORPORATION = {RequestModel.UnderCityCorporation}, " +
                                                               $"@P_USER_ID = {RequestModel.UserId}, @P_OPT = 'I'");

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
                            Message = "A PS/Upazila named " + RequestModel.PsUpazilaName + " already exists.",
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
                    ErrProcedure = "AddNewPsUpazila",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }
        }
        public async Task<CommonResponseModel> UpdatePsUpazilla(PsUpazilaRequestModel RequestModel)
        {
            try
            {
                int UpazilaCount = await Task.FromResult(_context.JcdPsUpazila
                                                               .FromSqlRaw($"SP_JCD_PS_OR_UPAZILA " +
                                                                           $"@P_PS_UPAZLA_ID = { RequestModel.PsUpazilaId}, " +
                                                                           $"@P_OPT = 'G'")
                                                               .AsEnumerable()
                                                               .Count());

                //var checkUpazila = await _context.JcdPsUpazila.Where(x => x.PsUpazlaName == RequestModel.PsUpazilaName && x.CityDistrictId == RequestModel.CityDistrictId).FirstOrDefaultAsync();
                if (UpazilaCount > 0)
                {
                    await _context.Database.ExecuteSqlRawAsync($"SP_JCD_PS_OR_UPAZILA @P_PS_UPAZLA_ID = {RequestModel.PsUpazilaId}, @P_PS_UPAZLA_NAME = '{RequestModel.PsUpazilaName}', " +
                                                               $"@P_CITY_DISTRICT_ID = {RequestModel.CityDistrictId}, @P_ACTIVE_STATUS = 1, " +
                                                               $"@P_UNDER_CITY_CORPORATION = {RequestModel.UnderCityCorporation}, " +
                                                               $"@P_USER_ID = {RequestModel.UserId}, @P_OPT = 'U'");

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
                            Message = "PS/Upazila no found.",
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
                    ErrProcedure = "UpdatePsUpazilla",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }
        }
        public async Task<CommonResponseModel> UpdatePsUpazilaStatus(int PsUpazilaId, byte Status)
        {
            try
            {
                int UpazilaCount = await Task.FromResult(_context.JcdPsUpazila
                                                               .FromSqlRaw($"SP_JCD_PS_OR_UPAZILA " +
                                                                           $"@P_PS_UPAZLA_ID = { PsUpazilaId}, " +
                                                                           $"@P_OPT = 'G'")
                                                               .AsEnumerable()
                                                               .Count());

                if (UpazilaCount > 0)
                {
                    await _context.Database.ExecuteSqlRawAsync($"SP_JCD_PS_OR_UPAZILA @P_PS_UPAZLA_ID = { PsUpazilaId}, " +
                                                               $"@P_ACTIVE_STATUS = {Status}, " +
                                                               $"@P_OPT = 'C'");

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
                            Message = "PS/Upazila not found.",
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
                    ErrMethodPayload = "Upazilla ID => " + PsUpazilaId + ", Status => " + Status,
                    ErrProcedure = "UpdatePsUpazilaStatus",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }
        }
        public async Task<UpazillaModel> GetUpazillaDetails()
        {
            try
            {
                List<UpazillaDetails> UpazillaDetails = await _context.UpazillaDetails
                                                         .FromSqlRaw($"SP_JCD_GET_ADDRESS_DETAILS @OPT_ID = 4")
                                                         .ToListAsync();

                //List<JcdCountryInfo> Countries = await _context.JcdCountryInfo.Where(x => x.ActiveStatus == 1).OrderBy(y => y.CountryName).ToListAsync();
                UpazillaModel Response = new UpazillaModel
                {
                    Status = "Success",
                    UpazillaDetails = UpazillaDetails
                };
                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                UpazillaModel CountryModel = new UpazillaModel
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
                    ErrMethodPayload = "GetUpazillaDetails",
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
