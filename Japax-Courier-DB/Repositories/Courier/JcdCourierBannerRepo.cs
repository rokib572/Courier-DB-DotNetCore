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
    public class JcdCourierBannerRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<CommonResponseModel> AddBanner(CourierBannerRequestModel BannerRequestModel)
        {
            try
            {
                string BannerInfoRequest = JsonConvert.SerializeObject(BannerRequestModel.BannerInfoModel);
                string BannerDetailsRequest = JsonConvert.SerializeObject(BannerRequestModel.BannerDetailsModel);

                var parameters = new[] {
                        new SqlParameter("@P_OPT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "I" },
                        new SqlParameter("@P_JSON_BANNER_INFO", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = BannerInfoRequest },
                        new SqlParameter("@P_JSON_BANNER_DET", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = BannerDetailsRequest }
                    };

                await Context.Database.ExecuteSqlRawAsync("SP_JSON_BANNER @P_OPT, @P_JSON_BANNER_INFO, @P_JSON_BANNER_DET", parameters);

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
                    ErrMethod = "AddBanner",
                    ErrMethodPayload = JsonConvert.SerializeObject(BannerRequestModel),
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
        public async Task<CommonResponseModel> UpdateBanner(CourierBannerUpdateModel BannerUpdateModel)
        {
            try
            {
                string BannerInfoRequest = JsonConvert.SerializeObject(BannerUpdateModel.BannerInfoModel);
                string BannerDetailsRequest = JsonConvert.SerializeObject(BannerUpdateModel.BannerDetailsModel);

                var parameters = new[] {
                        new SqlParameter("@P_OPT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "U" },
                        new SqlParameter("@P_JSON_BANNER_INFO", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = BannerInfoRequest },
                        new SqlParameter("@P_JSON_BANNER_DET", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = BannerDetailsRequest }
                    };

                await Context.Database.ExecuteSqlRawAsync("SP_JSON_BANNER @P_OPT, @P_JSON_BANNER_INFO, @P_JSON_BANNER_DET", parameters);

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
                    ErrMethod = "UpdateBanner",
                    ErrMethodPayload = JsonConvert.SerializeObject(BannerUpdateModel),
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
        public async Task<CourierBannerResponseModel> GetBannerDetails(byte BannerFor)
        {
            try
            {
                CourierBannerInfoResponseModel BannerDetails = await Task.FromResult(Context.Set<CourierBannerInfoResponseModel>()
                                                                                 .FromSqlRaw($"SP_JCD_GET_BANNER_DET {BannerFor}")
                                                                                 .AsEnumerable()
                                                                                 .FirstOrDefault());

                List<CourierBannerInfo> BannerInfo = JsonConvert.DeserializeObject<List<CourierBannerInfo>>(BannerDetails.BannerInfoModel);

                if (BannerDetails != null)
                {
                    CourierBannerResponseModel Response = new CourierBannerResponseModel
                    {
                        Status ="Success",
                        BannerInfoModel = BannerInfo
                    };

                    return await Task.FromResult(Response);
                } else
                {
                    CourierBannerResponseModel Response = new CourierBannerResponseModel
                    {
                        Status = "No Record Found",
                    };

                    return await Task.FromResult(Response);
                }
            } catch (Exception ex)
            {
                CourierBannerResponseModel Response = new CourierBannerResponseModel
                {
                    Status = "error",
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
                    ErrMethod = "GetBannerDetails",
                    ErrMethodPayload = "BannerFor => " + BannerFor,
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
