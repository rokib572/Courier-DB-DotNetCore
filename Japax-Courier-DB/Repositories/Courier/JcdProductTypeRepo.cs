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
    public class JcdProductTypeRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<ProductTypeModel> GetActiveProductTypes()
        {
            try
            {
                List<ProductTypeInfo> Result = await Context.ProductTypeInfo
                                                            .FromSqlRaw($"SP_JCD_PRODUCT_TYPE_OPERATION @P_OPT_ID = 'A'")
                                                            .ToListAsync();

                if (Result.Count > 0)
                {
                    ProductTypeModel Response = new ProductTypeModel
                    {
                        Status = "Success",
                        ProductTypes = Result
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    ProductTypeModel Response = new ProductTypeModel
                    {
                        Status = "Failed",
                        Error = new ErrorModel
                        {
                            ErrorCode = "530",
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
                ProductTypeModel Resposne = new ProductTypeModel
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
                    ErrMethodPayload = "GetProductTypes",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Resposne);
            }
        }
        public async Task<ProductTypeModel> GetProductTypeById (int ProductTypeId)
        {
            try
            {
                List<ProductTypeInfo> Result = await Context.ProductTypeInfo
                                                            .FromSqlRaw($"SP_JCD_PRODUCT_TYPE_OPERATION @P_OPT_ID = 'G', " +
                                                                        $"@P_PRODUCT_TYPE_ID = {ProductTypeId}")
                                                            .ToListAsync();

                if (Result.Count > 0)
                {
                    ProductTypeModel Response = new ProductTypeModel
                    {
                        Status = "Success",
                        ProductTypes = Result
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    ProductTypeModel Response = new ProductTypeModel
                    {
                        Status = "Failed",
                        Error = new ErrorModel
                        {
                            ErrorCode = "530",
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
                ProductTypeModel Resposne = new ProductTypeModel
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
                    ErrMethod = "GetProductTypeById",
                    ErrMethodPayload = "ProductTypeId => " + ProductTypeId,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Resposne);
            }
        }
        public async Task<ProductTypeModel> GetAllProducts()
        {
            try
            {
                List<ProductTypeInfo> Result = await Context.ProductTypeInfo
                                                            .FromSqlRaw($"SP_JCD_PRODUCT_TYPE_OPERATION @P_OPT_ID = 'O'")
                                                            .ToListAsync();

                if (Result.Count > 0)
                {
                    ProductTypeModel Response = new ProductTypeModel
                    {
                        Status = "Success",
                        ProductTypes = Result
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    ProductTypeModel Response = new ProductTypeModel
                    {
                        Status = "Failed",
                        Error = new ErrorModel
                        {
                            ErrorCode = "530",
                            InnerException = "",
                            Message = "No record found",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            } catch (Exception ex)
            {
                ProductTypeModel Resposne = new ProductTypeModel
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
                    ErrMethodPayload = "GetAllProducts",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Resposne);
            }            
        }
        public async Task<CommonResponseModel> AddProductType(ProductTypeInfo ProductType)
        {
            try
            {
                await Context.Database.ExecuteSqlRawAsync($"SP_JCD_PRODUCT_TYPE_OPERATION @P_OPT_ID = 'I', @P_PRODUCT_TYPE = '{ProductType.ProductType}', " +
                                                       $"@P_HANDLING_CHARGE = {ProductType.HandlingCharge}");

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success"
                };

                return await Task.FromResult(Response);
            } catch(Exception ex)
            {
                CommonResponseModel Resposne = new CommonResponseModel
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
                    ErrMethod = "AddProductType",
                    ErrMethodPayload = JsonConvert.SerializeObject(ProductType),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Resposne);
            }            
        }
        public async Task<CommonResponseModel> UpdateProductType(ProductTypeInfo ProductType)
        {
            try
            {
                await Context.Database.ExecuteSqlRawAsync($"SP_JCD_PRODUCT_TYPE_OPERATION @P_OPT_ID = 'U', @P_PRODUCT_TYPE_ID = {ProductType.ProductTypeId}," +
                                                          $"@P_PRODUCT_TYPE = '{ProductType.ProductType}', " +
                                                          $"@P_HANDLING_CHARGE = {ProductType.HandlingCharge}");

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success"
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                CommonResponseModel Resposne = new CommonResponseModel
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
                    ErrMethod = "UpdateProductType",
                    ErrMethodPayload = JsonConvert.SerializeObject(ProductType),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Resposne);
            }
        }
        public async Task<CommonResponseModel> ChangeProductTypeStatus(int ProductTypeId, byte Status)
        {
            try
            {
                await Context.Database.ExecuteSqlRawAsync($"SP_JCD_PRODUCT_TYPE_OPERATION @P_OPT_ID = 'C', @P_PRODUCT_TYPE_ID = {ProductTypeId}," +
                                                          $"@P_ACTIVE_STATUS = {Status}");

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success"
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                CommonResponseModel Resposne = new CommonResponseModel
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
                    ErrMethod = "UpdateProductType",
                    ErrMethodPayload = "ProductTypeId => " + ProductTypeId + ", Status => " + Status,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(Resposne);
            }
        }
    }
}
