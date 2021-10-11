using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdProvinceStateDivisionRepo
    {
        JpxCourierContext _context = new JpxCourierContext();

        public async Task<ProvinceModel> GetActiveStates()
        {
            try
            {
                List<JcdProvinceStateDivision> States = await _context.JcdProvinceStateDivision.Where(x => x.ActiveStatus == 1).OrderBy(y=> y.ProvinceName).ToListAsync();
                ProvinceModel _ProvinceModel = new ProvinceModel
                {
                    Status = "Success",
                    States = (from JcdProvinceStateDivision _State in States
                              select new ProvicneInfo
                              {
                                  CountryId = _State.CountryId,
                                  ProvinceId = _State.ProvinceId,
                                  ProvinceName = _State.ProvinceName
                              }).ToList()
                };
                return await Task.FromResult(_ProvinceModel);
            } catch(Exception ex)
            {
                ProvinceModel _ProvinceModel = new ProvinceModel
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

                return await Task.FromResult(_ProvinceModel);
            }
        }
        public async Task<ProvinceModel> GetStateById (int StateId)
        {
            try
            {
                JcdProvinceStateDivision _State = await _context.JcdProvinceStateDivision.Where(x => x.ProvinceId == StateId).FirstOrDefaultAsync();

                if(_State != null)
                {
                    ProvinceModel _ProvinceModel = new ProvinceModel
                    {
                        Status = "Success",
                        State = new ProvicneInfo
                        {
                            ProvinceId = _State.ProvinceId,
                            CountryId = _State.CountryId,
                            ProvinceName = _State.ProvinceName
                        }
                    };

                    return await Task.FromResult(_ProvinceModel);
                } else
                {
                    ProvinceModel _ProvinceModel = new ProvinceModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "513",
                            InnerException = "",
                            Message = "State or Province not found",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(_ProvinceModel);
                }
                
            } catch (Exception ex)
            {
                ProvinceModel _ProvinceModel = new ProvinceModel
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
                    ErrMethodPayload = "GetStateById",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_ProvinceModel);
            }
        }
        public async Task<ProvinceModel> GetStatesByCountry(int CountryId)
        {
            try
            {
                List<JcdProvinceStateDivision> States = await _context.JcdProvinceStateDivision.Where(x => x.CountryId == CountryId && x.ActiveStatus == 1).OrderBy(y => y.ProvinceName).ToListAsync();
                ProvinceModel _ProvinceModel = new ProvinceModel
                {
                    Status = "Success",
                    States = (from JcdProvinceStateDivision _State in States
                              select new ProvicneInfo
                              {
                                  CountryId = _State.CountryId,
                                  ProvinceId = _State.ProvinceId,
                                  ProvinceName = _State.ProvinceName
                              }).ToList()
                };
                return await Task.FromResult(_ProvinceModel);
            }
            catch (Exception ex)
            {
                ProvinceModel _ProvinceModel = new ProvinceModel
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

                return await Task.FromResult(_ProvinceModel);
            }
        }
        public async Task<CommonResponseModel> AddNewState(ProvinceRequestModel RequestModel)
        {
            try
            {
                int StateCount = await Task.FromResult(_context.JcdProvinceStateDivision
                                                               .FromSqlRaw($"SP_JCD_PROVINCE_STATE_OPERATION " +
                                                                           $"@P_PROVINCE_NAME = '{ RequestModel.StateName}', " +
                                                                           $"@P_OPT_ID = 'N'")
                                                               .AsEnumerable()
                                                               .Count());
                if (StateCount == 0)
                {
                    await _context.Database.ExecuteSqlRawAsync($"SP_JCD_PROVINCE_STATE_OPERATION @P_PROVINCE_NAME = '{RequestModel.StateName}', " +
                                                               $"@P_COUNTRY_ID = {RequestModel.CountryId}, @P_ACTIVE_STATUS = 1, " +
                                                               $"@P_USER_ID = {RequestModel.UserId}, @P_OPT_ID = 'I'");

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
                            Message = "A Province/State named " + RequestModel.StateName + " already exists.",
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
                    ErrProcedure = "AddNewState",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Response);
            }
        }
        public async Task<CommonResponseModel> UpdateState(ProvinceRequestModel RequestModel)
        {
            try
            {
                int StateCount = await Task.FromResult(_context.JcdProvinceStateDivision
                                                               .FromSqlRaw($"SP_JCD_PROVINCE_STATE_OPERATION " +
                                                                           $"@P_PROVINCE_ID = '{ RequestModel.ProvinceId}', " +
                                                                           $"@P_OPT_ID = 'G'")
                                                               .AsEnumerable()
                                                               .Count());
                if (StateCount > 0)
                {
                    await _context.Database.ExecuteSqlRawAsync($"SP_JCD_PROVINCE_STATE_OPERATION @P_PROVINCE_ID = {RequestModel.ProvinceId}, " +
                                                               $"@P_PROVINCE_NAME = '{RequestModel.StateName}', " +
                                                               $"@P_COUNTRY_ID = {RequestModel.CountryId}, @P_ACTIVE_STATUS = 1, " +
                                                               $"@P_USER_ID = {RequestModel.UserId}, @P_OPT_ID = 'U'");

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
                            Message = "Province/State " + RequestModel.StateName + " was not found.",
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
                    ErrProcedure = "UpdateState",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Response);
            }
        }
        public async Task<CommonResponseModel> ChangeProvinceStatus(byte ProvinceId, byte Status)
        {
            try
            {
                int StateCount = await Task.FromResult(_context.JcdProvinceStateDivision
                                                               .FromSqlRaw($"SP_JCD_PROVINCE_STATE_OPERATION " +
                                                                           $"@P_PROVINCE_ID = '{ ProvinceId}', " +
                                                                           $"@P_OPT_ID = 'G'")
                                                               .AsEnumerable()
                                                               .Count());
                if (StateCount > 0)
                {
                    await _context.Database.ExecuteSqlRawAsync($"SP_JCD_PROVINCE_STATE_OPERATION @P_PROVINCE_ID = {ProvinceId}, " +
                                                               $"@P_ACTIVE_STATUS = {Status}, @P_OPT_ID = 'C'");

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
                            Message = "Province/State not found.",
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
                    ErrMethodPayload = "ProvinceId = " + ProvinceId + ", Status = " + Status,
                    ErrProcedure = "UpdateState",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Response);
            }
        }
        public async Task<ProvinceModel> GetStateDetails()
        {
            try
            {
                List<ProvinceDetails> ProvinceList = await _context.ProvinceDetails
                                                         .FromSqlRaw($"SP_JCD_GET_ADDRESS_DETAILS @OPT_ID = 2")
                                                         .ToListAsync();

                ProvinceModel Response = new ProvinceModel
                {
                    Status = "Success",
                    ProvinceDetails = ProvinceList
                };

                return await Task.FromResult(Response);
            } catch(Exception ex)
            {
                ProvinceModel _ProvinceModel = new ProvinceModel
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
                    ErrMethodPayload = "GetStateDetails",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_ProvinceModel);
            }            
        }
    }
}
