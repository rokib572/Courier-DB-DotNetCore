using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdPackageWithWeightChargeRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<PackageWithChargeResponseModel> GetActivePackageTypes()
        {
            try
            {
                List<PackageWithChargeInfo> Packages = await Context.PackageWithChargeInfo
                                                                .FromSqlRaw($"SP_JCD_PACKAGE_WITH_CHARGE_OPERATION @P_OPT_ID = 'A'")
                                                                .ToListAsync();

                if (Packages.Count > 0)
                {
                    PackageWithChargeResponseModel Response = new PackageWithChargeResponseModel
                    {
                        Status = "Success",
                        Pacakges = Packages
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    PackageWithChargeResponseModel Response = new PackageWithChargeResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            StackTrace = "",
                            ErrorCode = "531",
                            InnerException = "",
                            Message = "No record found"
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                PackageWithChargeResponseModel Response = new PackageWithChargeResponseModel
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
                    ErrMethodPayload = "GetAllPackageTypes",
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
        public async Task<PackageWithChargeResponseModel> GetAllPackageTypes()
        {
            try
            {
                List<PackageWithChargeInfo> Packages = await Context.PackageWithChargeInfo
                                                                .FromSqlRaw($"SP_JCD_PACKAGE_WITH_CHARGE_OPERATION @P_OPT_ID = 'O'")
                                                                .ToListAsync();

                if (Packages.Count > 0)
                {
                    PackageWithChargeResponseModel Response = new PackageWithChargeResponseModel
                    {
                        Status = "Success",
                        Pacakges = Packages
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    PackageWithChargeResponseModel Response = new PackageWithChargeResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            StackTrace = "",
                            ErrorCode = "531",
                            InnerException = "",
                            Message = "No record found"
                        }
                    };

                    return await Task.FromResult(Response);
                }
            } catch(Exception ex)
            {
                PackageWithChargeResponseModel Response = new PackageWithChargeResponseModel
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
                    ErrMethodPayload = "GetAllPackageTypes",
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
        public async Task<PackageWithChargeResponseModel> GetPackageTypeById(int PackageTypeId)
        {
            try
            {
                List<PackageWithChargeInfo> Packages = await Context.PackageWithChargeInfo
                                                                .FromSqlRaw($"SP_JCD_PACKAGE_WITH_CHARGE_OPERATION @P_OPT_ID = 'G', " +
                                                                            $"@P_PACKAGE_CHARGE_ID = {PackageTypeId}")
                                                                .ToListAsync();

                if (Packages.Count > 0)
                {
                    PackageWithChargeResponseModel Response = new PackageWithChargeResponseModel
                    {
                        Status = "Success",
                        Pacakges = Packages
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    PackageWithChargeResponseModel Response = new PackageWithChargeResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            StackTrace = "",
                            ErrorCode = "531",
                            InnerException = "",
                            Message = "No record found"
                        }
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                PackageWithChargeResponseModel Response = new PackageWithChargeResponseModel
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
                    ErrMethod = "GetPackageTypeById",
                    ErrMethodPayload = "PackageTypeId => " + PackageTypeId,
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
        public async Task<CommonResponseModel> AddPackageType(PackageWithChargeInfo PackageType)
        {
            try
            {
                await Context.Database.ExecuteSqlRawAsync($"SP_JCD_PACKAGE_WITH_CHARGE_OPERATION @P_OPT_ID = 'I', @P_PACKAGE_TYPE ='{PackageType.PackageType}', " +
                                                          $"@P_PACKAGE_WIDTH = {PackageType.PackageWidth}, @P_PACKAGE_HEIGHT = {PackageType.PackageHeight}, " +
                                                          $"@P_PACKAGE_LENGTH = {PackageType.PackageLength}, @P_DIMENSION_UNIT = '{PackageType.DimensionUnit}', " +
                                                          $"@P_PACKAGE_WEIGHT = {PackageType.PackageWeight}, @P_WEIGHT_UNIT = '{PackageType.WeightUnit}', " +
                                                          $"@P_PACKAGE_DETAILS = '{PackageType.PackageDetails}',@P_PACKAGE_CHARGE = {PackageType.PackageCharge}, " +
                                                          $"@P_USER_ID = {PackageType.UserId}");
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success"
                };

                return await Task.FromResult(Response);
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
                    ErrMethod = "AddPackageType",
                    ErrMethodPayload = JsonConvert.SerializeObject(PackageType),
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
        public async Task<CommonResponseModel> UpdatePackageType(PackageWithChargeInfo PackageType)
        {
            try
            {
                await Context.Database.ExecuteSqlRawAsync($"SP_JCD_PACKAGE_WITH_CHARGE_OPERATION @P_OPT_ID = 'U', @P_PACKAGE_CHARGE_ID = {PackageType.PackageTypeId}, @P_PACKAGE_TYPE ='{PackageType.PackageType}', " +
                                                          $"@P_PACKAGE_WIDTH = {PackageType.PackageWidth}, @P_PACKAGE_HEIGHT = {PackageType.PackageHeight}, " +
                                                          $"@P_PACKAGE_LENGTH = {PackageType.PackageLength}, @P_DIMENSION_UNIT = '{PackageType.DimensionUnit}', " +
                                                          $"@P_PACKAGE_WEIGHT = {PackageType.PackageWeight}, @P_WEIGHT_UNIT = '{PackageType.WeightUnit}', " +
                                                          $"@P_PACKAGE_DETAILS = '{PackageType.PackageDetails}',@P_PACKAGE_CHARGE = {PackageType.PackageCharge}, " +
                                                          $"@P_USER_ID = {PackageType.UserId}");
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
                    ErrMethod = "UpdatePackageType",
                    ErrMethodPayload = JsonConvert.SerializeObject(PackageType),
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
        public async Task<CommonResponseModel> ChangePackageTypeStatus(int PackageTypeId, byte Status)
        {
            try
            {
                await Context.Database.ExecuteSqlRawAsync($"SP_JCD_PACKAGE_WITH_CHARGE_OPERATION @P_OPT_ID = 'C', " +
                                                              $"@P_PACKAGE_CHARGE_ID = {PackageTypeId}, @P_ACTIVE_STATUS = {Status}");

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
                    ErrMethod = "ChangePackageTypeStatus",
                    ErrMethodPayload = "PackageTypeId => " + PackageTypeId + ", Status => " + Status,
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
