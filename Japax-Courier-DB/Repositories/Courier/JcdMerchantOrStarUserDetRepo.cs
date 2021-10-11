using Japax_Courier_DB.DBModels.Auth;
using Japax_Courier_DB.DBModels.Auth.Models;
using Japax_Courier_DB.DBModels.Auth.Models.Request;
using Japax_Courier_DB.DBModels.Auth.Models.Response;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.Repositories.Auth;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdMerchantOrStarUserDetRepo
    {
        JpxCourierContext Context = new JpxCourierContext();
        public async Task<CommonResponseModel> AddMerchant_Old(MerchantRegistrationRequestModel Request)
        {
            JpxUserLoginInfoRepo LoginRepo = new JpxUserLoginInfoRepo();

            UserRegistrationResponseModel SenderInfo = await LoginRepo.AddNewUser(Request);

            try
            {
                if(SenderInfo.Status == "Success")
                {
                    JcdSenderInfoRepo SenderInfoRepo = new JcdSenderInfoRepo();

                    JcdSenderInfo _SenderInfo = new JcdSenderInfo
                    {
                        ActiveStatus = 1,
                        AllowableAddress = 10,
                        RewardPoint = 0,
                        SenderId = SenderInfo.LoginInfo.LoginId,
                        SenderType = Request.SenderType
                    };
                    CommonResponseModel Result = await SenderInfoRepo.AddNew(_SenderInfo);

                    if(Result.Status == "Success")
                    {
                        JcdMerchantOrStarUserDet MerchantDetails = new JcdMerchantOrStarUserDet
                        {
                            ClientEmail = Request.RepresentativeEmail,
                            ClientFirstName = Request.RepresentativeFirstName,
                            ClientLastName = Request.RepresentativeLastName,
                            ClientLogo = Request.CompanyLogo,
                            ClientMobileNo = Request.RepresentativeMobileNo,
                            Bin = Request.BinNo,
                            CompanyName = Request.CompanyName,
                            //CreditDays = Request.CreditLimitDays,
                            //CreditLimit = Request.CreditLimit,
                            //DefaultPaymentMethod = Request.DefaultPaymentMethod,
                            DrivingLicenseNo = Request.DrivingLicenseNo,
                            FacebookLink = Request.FacebookPageLink,
                            Nid = Request.NationalIdNo,
                            OthersLink = Request.OtherLink,
                            Remarks = Request.Remarks,
                            SenderId = SenderInfo.LoginInfo.LoginId,
                            TradeLicenseNo = Request.TradeLicenseNo,
                            Twiter = Request.TwitterLink,
                            Website = Request.WebsiteAddress
                        };

                        await Context.JcdMerchantOrStarUserDet.AddAsync(MerchantDetails);
                        await Context.SaveChangesAsync();

                        CommonResponseModel Response = new CommonResponseModel
                        {
                            Status = "Success"
                        };

                        return await Task.FromResult(Response);
                    } else
                    {
                        await LoginRepo.RemoveUserInfo(SenderInfo.LoginInfo.LoginId);

                        CommonResponseModel Response = new CommonResponseModel
                        {
                            Status = Result.Status,
                            Error = Result.Error
                        };

                        return await Task.FromResult(Response);
                    }
                    
                } else
                {
                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = SenderInfo.Status,
                        Error = SenderInfo.Error
                    };

                    return await Task.FromResult(Response);
                }
                
            } catch (Exception ex)
            {
                await LoginRepo.RemoveUserInfo(SenderInfo.LoginInfo.LoginId);

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
                JpxErrorLogRepo _LogRepo = new JpxErrorLogRepo();
                JpxErrorLog _ErrorLog = new JpxErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "AddMerchant",
                    ErrMethodPayload = JsonConvert.SerializeObject(Request),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    //UserId = Request.SenderId
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(Response);
            }
        }
        public async Task<CommonResponseModel> AddMerchant(MerchantRegistrationRequestModel Request)
        {
            try
            {
                JpxUserLoginInfoRepo LoginRepo = new JpxUserLoginInfoRepo();
                JpxUserLoginInfoModel _CheckUser = await LoginRepo.GetUserByPhone(Request.RepresentativeMobileNo);

                if(_CheckUser.UserAuthModel == null)
                {
                    var parameters = new[] {
                        new SqlParameter("@P_OPT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = 'I' },
                        new SqlParameter("@LOGIN_ID", SqlDbType.BigInt) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@USER_MOBILE_NO", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.RepresentativeMobileNo },
                        new SqlParameter("@USER_FIRST_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.RepresentativeFirstName },
                        new SqlParameter("@USER_LAST_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.RepresentativeLastName },
                        new SqlParameter("@USER_EMAIL", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.RepresentativeEmail },
                        new SqlParameter("@PROFILE_PICTURE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.CompanyLogo },
                        new SqlParameter("@DEVICE_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.DeviceId },
                        new SqlParameter("@DEVICE_TYPE", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = Request.DeviceType },
                        new SqlParameter("@FCM_TOKEN", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.FcmToken },
                        new SqlParameter("@SECRET_KEY", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.SecretKey },
                        new SqlParameter("@ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@COURIER_APP", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = Request.CourierApp },
                        new SqlParameter("@RIDESHARE_APP", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = Request.RideshareApp },
                        new SqlParameter("@ALLOWABLE_ADDRESS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 10 },
                        new SqlParameter("@SENDER_TYPE", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = Request.SenderType },
                        new SqlParameter("@COMPANY_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.CompanyName },
                        new SqlParameter("@WEBSITE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.WebsiteAddress },
                        new SqlParameter("@FACEBOOK_LINK", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.FacebookPageLink },
                        new SqlParameter("@TWITER", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.TwitterLink },
                        new SqlParameter("@OTHERS_LINK", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.OtherLink },
                        new SqlParameter("@TRADE_LICENSE_NO", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = Request.TradeLicenseNo },
                        new SqlParameter("@BIN", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = Request.BinNo },
                        new SqlParameter("@NID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = Request.NationalIdNo },
                        new SqlParameter("@DRIVING_LICENSE_NO", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.DrivingLicenseNo },
                        new SqlParameter("@CREDIT_LIMIT", SqlDbType.Money) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@CREDIT_DAYS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@DEFAULT_PAYMENT_METHOD", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@REMARKS", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Request.Remarks }
                    };

                    await Context.Database.ExecuteSqlRawAsync("SP_JCD_MERCHANT_OPERATION @P_OPT_ID, @LOGIN_ID, @USER_MOBILE_NO, @USER_FIRST_NAME, " +
                                                                    "@USER_LAST_NAME, @USER_EMAIL, @PROFILE_PICTURE, @DEVICE_ID, @DEVICE_TYPE, " +
                                                                    "@FCM_TOKEN, @SECRET_KEY, @ACTIVE_STATUS, @COURIER_APP, @RIDESHARE_APP, @ALLOWABLE_ADDRESS, " +
                                                                    "@SENDER_TYPE, @COMPANY_NAME, @WEBSITE, @FACEBOOK_LINK, @TWITER, @OTHERS_LINK, " +
                                                                    "@TRADE_LICENSE_NO, @BIN, @NID, @DRIVING_LICENSE_NO, @CREDIT_LIMIT, @CREDIT_DAYS, " +
                                                                    "@DEFAULT_PAYMENT_METHOD, @REMARKS"
                                                                    , parameters);

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
                            ErrorCode = "533",
                            InnerException = "",
                            Message = "User Already Exists.",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
                

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
                JpxErrorLogRepo _LogRepo = new JpxErrorLogRepo();
                JpxErrorLog _ErrorLog = new JpxErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "AddMerchant",
                    ErrMethodPayload = JsonConvert.SerializeObject(Request),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    //UserId = Request.SenderId
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(Response);
            }            
        }
        public async Task<CommonResponseModel> UpdateMerchant(MerchantUpdateRequestModel Request) 
        {
            try
            {
                JcdMerchantOrStarUserDet MerchantDetails = await Context.JcdMerchantOrStarUserDet.Where(x => x.SenderId == Request.SenderId).FirstOrDefaultAsync();

                if(MerchantDetails != null)
                {
                    MerchantDetails.ClientFirstName = Request.RepresentativeFirstName;
                    MerchantDetails.ClientLastName = Request.RepresentativeLastName;
                    MerchantDetails.ClientEmail = Request.RepresentativeEmail;
                    MerchantDetails.ClientLogo = Request.CompanyLogo;
                    MerchantDetails.FacebookLink = Request.FacebookPageLink;
                    MerchantDetails.Twiter = Request.TwitterLink;
                    MerchantDetails.OthersLink = Request.OtherLink;
                    MerchantDetails.CreditLimit = Request.CreditLimit;
                    MerchantDetails.CreditDays = Request.CreditLimitDays;
                    MerchantDetails.DefaultPaymentMethod = Request.DefaultPaymentMethod;
                    MerchantDetails.Remarks = Request.Remarks;

                    await Context.SaveChangesAsync();

                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Success",
                    };

                    return await Task.FromResult(Response);
                } else
                {
                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "534",
                            Message = "Merchant Not Found!",
                            StackTrace = "",
                            InnerException = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
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
                JpxErrorLogRepo _LogRepo = new JpxErrorLogRepo();
                JpxErrorLog _ErrorLog = new JpxErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "UpdateMerchant",
                    ErrMethodPayload = JsonConvert.SerializeObject(Request),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = Request.SenderId
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(Response);
            }
        }
    }
}
