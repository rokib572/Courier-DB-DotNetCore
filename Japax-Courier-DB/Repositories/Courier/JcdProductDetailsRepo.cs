using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdProductDetailsRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<ProductDetailsResponseModel> GetProductDetailsByRequestId(long RequestId)
        {
            try
            {
                //ProductDetailsInfo ProductDetails = await Task.FromResult(Context.Set<ProductDetailsInfo>()
                //                                         .FromSqlRaw("SP_JCD_GET_PICKUP_AND_DELIVERY_DET @P_REQUEST_ID =" + RequestId + "")
                //                                         .AsEnumerable()
                //                                         .FirstOrDefault());

                List<ProductDetailsInfo> ProductDetails = await Context.ProductDetailsInfo
                                                         .FromSqlRaw($"SP_JCD_GET_PICKUP_AND_DELIVERY_DET {RequestId}")
                                                         .ToListAsync();

                if (ProductDetails != null)
                {
                    ProductDetailsResponseModel Response = new ProductDetailsResponseModel
                    {
                        Status = "Success",
                        ProductDetails = ProductDetails
                    };

                    return await Task.FromResult(Response);
                } else
                {
                    ProductDetailsResponseModel Response = new ProductDetailsResponseModel
                    {
                        Status = "No Data Found!",
                    };

                    return await Task.FromResult(Response);
                }
            }
            catch (Exception ex)
            {
                ProductDetailsResponseModel RequestList = new ProductDetailsResponseModel
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
                    ErrMethodPayload = "GetProductDetailsByRequestId",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(RequestList);
            }
        }
        public async Task<CommonResponseModel> AddProductImage(List<ProductImageRequestModel> Request)
        {
            try
            {
                string ImageJson = JsonConvert.SerializeObject(Request);

                var parameters = new[] {
                        new SqlParameter("@P_OPT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = 'I' },
                        new SqlParameter("@P_IMAGE_JSON", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = ImageJson }
                    };

                await Context.Database.ExecuteSqlRawAsync("SP_JCD_JSON_PRODUCT_IMAGE_UPDATE_OPERATION @P_OPT_ID, " +
                                                          $"@P_IMAGE_JSON", parameters);


                CommonResponseModel Resposne = new CommonResponseModel
                {
                    Status = "Success"
                };

                return await Task.FromResult(Resposne);

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
                    ErrMethod = "AddProductImage",
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
    }
}
