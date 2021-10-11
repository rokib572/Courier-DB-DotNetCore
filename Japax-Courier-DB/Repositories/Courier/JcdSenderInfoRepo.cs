using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdSenderInfoRepo
    {
        JpxCourierContext _Context = new JpxCourierContext();

        public async Task<CommonResponseModel> AddNew(JcdSenderInfo _SenderInfo)
        {
            try
            {
                await _Context.JcdSenderInfo.AddAsync(_SenderInfo);
                await _Context.SaveChangesAsync();
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
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
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
                    ErrMethodPayload = "AddNewSenderInfo",
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
        public async Task<CommonResponseModel> Update(JcdSenderInfo _SenderInfo)
        {
            try
            {
                _Context.JcdSenderInfo.Update(_SenderInfo);
                await _Context.SaveChangesAsync();
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
                        InnerException = ex.InnerException.Message.ToString(),
                        Message = ex.Message.ToString(),
                        StackTrace = ex.StackTrace.ToString()
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
                    ErrMethodPayload = "UpdateSenderInfo",
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
        public async Task<SenderDetailsRespModel> GetUserByType (byte SenderType, byte ActiveStatus)
        {
            try
            {
                List<SenderDetailsResponseModel> SenderDetails = await _Context.SenderDetailsResponseModel
                                                                     .FromSqlRaw($"SP_JCD_GET_SENDER_DET @P_SENDER_TYPE = {SenderType}, " +
                                                                                 $"@P_ACTIVE_STATUS = {ActiveStatus}")
                                                                     .ToListAsync();

                if(SenderDetails.Count > 0)
                {
                    SenderDetailsRespModel Response = new SenderDetailsRespModel
                    {
                        Status = "Success",
                        SenderDetails = SenderDetails
                    };

                    return await Task.FromResult(Response);
                } else
                {
                    SenderDetailsRespModel Response = new SenderDetailsRespModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            StackTrace = "",
                            ErrorCode = "533",
                            InnerException = "",
                            Message = "No Records found!"
                        }
                    };

                    return await Task.FromResult(Response);
                }

            } catch (Exception ex)
            {
                SenderDetailsRespModel Response = new SenderDetailsRespModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    }
                };
                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "GetUserByType",
                    ErrMethodPayload = "SenderType => " + SenderType + " ActiveStatus => " + ActiveStatus,
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
        public async Task<SenderDetailsRespModel> GetUserById(long SenderId)
        {
            try
            {
                List<SenderDetailsResponseModel> SenderDetails = await _Context.SenderDetailsResponseModel
                                                                     .FromSqlRaw($"SP_JCD_GET_SENDER_DET_BY_ID @P_SENDER_ID = {SenderId}")
                                                                     .ToListAsync();

                if (SenderDetails.Count > 0)
                {
                    SenderDetailsRespModel Response = new SenderDetailsRespModel
                    {
                        Status = "Success",
                        SenderDetails = SenderDetails
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    SenderDetailsRespModel Response = new SenderDetailsRespModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            StackTrace = "",
                            ErrorCode = "533",
                            InnerException = "",
                            Message = "No Records found!"
                        }
                    };

                    return await Task.FromResult(Response);
                }

            }
            catch (Exception ex)
            {
                SenderDetailsRespModel Response = new SenderDetailsRespModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    }
                };
                //<<<<<Start Register Log>>>>>
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "GetUserById",
                    ErrMethodPayload = "SenderId => " + SenderId,
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
