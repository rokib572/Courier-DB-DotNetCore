using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdAdditionalPackagingChargeRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<CommonResponseModel> AddNewExtraPackage(ExtraPackagingTypeInfo RequestModel)
        {
            try
            {
                int TotalRecord = await Task.FromResult(Context.ExtraPackagingTypeInfo.FromSqlRaw($"SP_JCD_EXTRA_PACKAGING_OPERATION @OPT_ID = 'N', " +
                                                                            $"@P_PACKAGING_TYPE = '" + RequestModel.PackagingType + "'")
                                                                .AsEnumerable()
                                                                .Count());
                
                if(TotalRecord == 0)
                {
                    await Context.Database.ExecuteSqlRawAsync($"SP_JCD_EXTRA_PACKAGING_OPERATION @OPT_ID = 'I', " +
                                                              $"@P_PACKAGING_TYPE = '{RequestModel.PackagingType}', " +
                                                              $"@P_PACKAGING_CHARGE = {RequestModel.PackagingCharge}");

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
                            Message = "Package Type " + RequestModel.PackagingType + " already exits.",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            } catch(Exception ex)
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
                    ErrProcedure = "AddNewExtraPackage",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(Response);
            }
        }
        public async Task<CommonResponseModel> UpdateExtraPackage(ExtraPackagingTypeInfo RequestModel)
        {
            try
            {
                int TotalRecord = await Task.FromResult(Context.ExtraPackagingTypeInfo.FromSqlRaw($"SP_JCD_EXTRA_PACKAGING_OPERATION @OPT_ID = 'G', " +
                                                                            $"@P_EXTRA_PACKAGING_ID = {RequestModel.ExtraPackagingId}")
                                                                .AsEnumerable()
                                                                .Count());
                if (TotalRecord > 0)
                {
                    await Context.Database.ExecuteSqlRawAsync($"SP_JCD_EXTRA_PACKAGING_OPERATION @OPT_ID = 'U', " +
                                                              $"@P_EXTRA_PACKAGING_ID = {RequestModel.ExtraPackagingId}," +
                                                              $"@P_PACKAGING_TYPE = '{RequestModel.PackagingType}', " +
                                                              $"@P_PACKAGING_CHARGE = {RequestModel.PackagingCharge}");

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
                            Message = "Package Type not found.",
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
                    ErrProcedure = "UpdateExtraPackage",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(Response);
            }
        }
        public async Task<CommonResponseModel> ChangeExtraPackageStatus (byte ExtraPackageId, byte Status)
        {
            try
            {
                int TotalRecord = await Task.FromResult(Context.ExtraPackagingTypeInfo.FromSqlRaw($"SP_JCD_EXTRA_PACKAGING_OPERATION @OPT_ID = 'G', " +
                                                                            $"@P_EXTRA_PACKAGING_ID = {ExtraPackageId}")
                                                                .AsEnumerable()
                                                                .Count());
                if (TotalRecord > 0)
                {
                    await Context.Database.ExecuteSqlRawAsync($"SP_JCD_EXTRA_PACKAGING_OPERATION @OPT_ID = 'C', " +
                                                              $"@P_EXTRA_PACKAGING_ID = {ExtraPackageId}," +
                                                              $"@P_ACTIVE_STATUS = {Status}");

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
                            Message = "Package Type not found.",
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
                    ErrMethodPayload = "ExtraPackageId => " + ExtraPackageId + ", Status => " + Status,
                    ErrProcedure = "ChangeExtraPackageStatus",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(Response);
            }
        }
        public async Task<ExtraPackagingTypeModel> GetExtraPackagingType()
        {
            try
            {
                //await Context.Database.ExecuteSqlRawAsync($"SP_JCD_EXTRA_PACKAGING_OPERATION @OPT_ID = 'A');
                List<ExtraPackagingTypeInfo> ExtraPackageTypes = await Context.ExtraPackagingTypeInfo
                                                                              .FromSqlRaw($"SP_JCD_EXTRA_PACKAGING_OPERATION @OPT_ID = 'O'")
                                                                              .ToListAsync();

                if(ExtraPackageTypes.Count > 0)
                {
                    ExtraPackagingTypeModel Response = new ExtraPackagingTypeModel
                    {
                        Status = "Success",
                        ExtraPackageTypes = ExtraPackageTypes
                    };
                    return await Task.FromResult(Response);
                } else
                {
                    ExtraPackagingTypeModel Response = new ExtraPackagingTypeModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "523",
                            InnerException = "",
                            Message = "No record found",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }                
            }
            catch (Exception ex)
            {
                ExtraPackagingTypeModel Response = new ExtraPackagingTypeModel
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

                return await Task.FromResult(Response);
            }
        }
        public async Task<ExtraPackagingTypeModel> GetActiveExtraPackagingType()
        {
            try
            {
                //await Context.Database.ExecuteSqlRawAsync($"SP_JCD_EXTRA_PACKAGING_OPERATION @OPT_ID = 'A');
                List<ExtraPackagingTypeInfo> ExtraPackageTypes = await Context.ExtraPackagingTypeInfo
                                                                              .FromSqlRaw($"SP_JCD_EXTRA_PACKAGING_OPERATION @OPT_ID = 'A'")
                                                                              .ToListAsync();

                if (ExtraPackageTypes.Count > 0)
                {
                    ExtraPackagingTypeModel Response = new ExtraPackagingTypeModel
                    {
                        Status = "Success",
                        ExtraPackageTypes = ExtraPackageTypes
                    };
                    return await Task.FromResult(Response);
                }
                else
                {
                    ExtraPackagingTypeModel Response = new ExtraPackagingTypeModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "523",
                            InnerException = "",
                            Message = "No record found",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                ExtraPackagingTypeModel Response = new ExtraPackagingTypeModel
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

                return await Task.FromResult(Response);
            }
        }
        public async Task<ExtraPackagingTypeModel> GetExtraPackingById(byte ExtraPackageId)
        {
            try
            {
                ExtraPackagingTypeInfo ExtraPackageType = await Task.FromResult(Context.ExtraPackagingTypeInfo
                                                                              .FromSqlRaw($"SP_JCD_EXTRA_PACKAGING_OPERATION @OPT_ID = 'G'," +
                                                                              $"@P_EXTRA_PACKAGING_ID = {ExtraPackageId}")
                                                                              .AsEnumerable()
                                                                              .FirstOrDefault());

                ExtraPackagingTypeModel Response = new ExtraPackagingTypeModel
                {
                    Status = "Success",
                    ExtraPackageType = ExtraPackageType
                };
                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                ExtraPackagingTypeModel Response = new ExtraPackagingTypeModel
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
                    ErrMethodPayload = "GetExtraPackingById => ExtraPackageId = " + ExtraPackageId,
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
