using System;
using System.Collections.Generic;
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
    public class JcdManifestInfoRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<CommonResponseModel> CreateManifest(ManifestInfoRequestModel Request)
        {
            try
            {
                await Context.Database
                            .ExecuteSqlRawAsync($"SP_JCD_MANIFEST_INFO_OPERATION @P_OPT_ID = 'I', " +
                                                $"@P_REQUEST_ID = '{Request.RequestId}'," +
                                                $"@P_PICKUP_POINT_ID = {Request.PickupPointId}," +
                                                $"@P_DROP_POINT_ID = {Request.DropPointId}," +
                                                $"@P_NO_OF_REQUEST = {Request.NoOfRequest}," +
                                                $"@P_TRACKING_NO = '{Request.TrackingNo}'," +
                                                $"@P_USER_ID = {Request.UserId}");

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
                    ErrMethod = "CreateManifest",
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
        public async Task<CommonResponseModel> UpdateManifest(ManifestInfoRequestModel Request)
        {
            try
            {
                await Context.Database
                            .ExecuteSqlRawAsync($"SP_JCD_MANIFEST_INFO_OPERATION @P_OPT_ID = 'U', " +
                                                $"@P_REQUEST_ID = '{Request.RequestId}'," +
                                                $"@P_MANIFEST_ID = {Request.ManifestId}," +
                                                $"@P_PICKUP_POINT_ID = {Request.PickupPointId}," +
                                                $"@P_DROP_POINT_ID = {Request.DropPointId}," +
                                                $"@P_NO_OF_REQUEST = {Request.NoOfRequest}," +
                                                $"@P_TRACKING_NO = '{Request.TrackingNo}'," +
                                                $"@P_USER_ID = {Request.UserId}");

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
                    ErrMethod = "UpdateManifest",
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
        public async Task<ManifestInfoResponseModel> GetManifestById(long ManifestId)
        {
            try
            {
                List<ManifestInfo> ManifestInfo = await Context.ManifestInfo
                                                                  .FromSqlRaw($"SP_JCD_MANIFEST_INFO_OPERATION @P_OPT_ID = 'G'," +
                                                                              $"@P_MANIFEST_ID = {ManifestId}")
                                                                  .ToListAsync();

                if (ManifestInfo.Count > 0)
                {
                    ManifestInfoResponseModel Response = new ManifestInfoResponseModel
                    {
                        Status = "Success",
                        ManifestInfo = ManifestInfo
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    ManifestInfoResponseModel Response = new ManifestInfoResponseModel
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
                ManifestInfoResponseModel Response = new ManifestInfoResponseModel
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
                    ErrMethod = "GetManifestById",
                    ErrMethodPayload = "ManifestId => " + ManifestId,
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
        public async Task<ManifestInfoResponseModel> GetAllManifest()
        {
            try
            {
                List<ManifestInfo> ManifestInfo = await Context.ManifestInfo
                                                                  .FromSqlRaw($"SP_JCD_MANIFEST_INFO_OPERATION @P_OPT_ID = 'O'")
                                                                  .ToListAsync();

                if (ManifestInfo.Count > 0)
                {
                    ManifestInfoResponseModel Response = new ManifestInfoResponseModel
                    {
                        Status = "Success",
                        ManifestInfo = ManifestInfo
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    ManifestInfoResponseModel Response = new ManifestInfoResponseModel
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
                ManifestInfoResponseModel Response = new ManifestInfoResponseModel
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
                    ErrMethod = "GetAllManifest",
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
        public async Task<ManifestInfoResponseModel> GetActiveManifest()
        {
            try
            {
                List<ManifestInfo> ManifestInfo = await Context.ManifestInfo
                                                                  .FromSqlRaw($"SP_JCD_MANIFEST_INFO_OPERATION @P_OPT_ID = 'A'")
                                                                  .ToListAsync();

                if (ManifestInfo.Count > 0)
                {
                    ManifestInfoResponseModel Response = new ManifestInfoResponseModel
                    {
                        Status = "Success",
                        ManifestInfo = ManifestInfo
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    ManifestInfoResponseModel Response = new ManifestInfoResponseModel
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
                ManifestInfoResponseModel Response = new ManifestInfoResponseModel
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
                    ErrMethod = "GetActiveManifest",
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
