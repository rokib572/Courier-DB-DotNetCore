using Japax_Courier_DB.Cipher;
using Japax_Courier_DB.DBModels.Auth.Models;
using Japax_Courier_DB.DBModels.Auth.Models.Request;
using Japax_Courier_DB.DBModels.Auth.Models.Response;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Japax_Courier_DB.Repositories.Auth;
using Japax_Courier_DB.Repositories.Courier;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Japax_Courier_DB.Clients
{
    //UserInfo Client
    public class UClient
    {
        public async Task<UserRegistrationResponseModel> RegisterUser(UserInfoModel _UserInfo)
        {
            JpxUserLoginInfoRepo _UserInfoRepo = new JpxUserLoginInfoRepo();
            JcdSenderInfoRepo _SenderInfoRepo = new JcdSenderInfoRepo();

            if (_UserInfo.UserMobileNo.ToString().Trim().Length < 14 ^ _UserInfo.UserMobileNo.ToString().Trim().Length > 20)
            {
                UserRegistrationResponseModel RegistrationResponseError = new UserRegistrationResponseModel
                {
                    Error = new ErrorModel
                    {
                        ErrorCode = "512",
                        InnerException = "",
                        Message = "Phone Number is not valid",
                        StackTrace = "",
                    },
                    Status = "Error"
                };

                return await Task.FromResult(RegistrationResponseError);
            } else if(_UserInfo.DeviceId == "" ^ _UserInfo.DeviceId == null)
            {
                UserRegistrationResponseModel RegistrationResponseError = new UserRegistrationResponseModel
                {
                    Error = new ErrorModel
                    {
                        ErrorCode = "512",
                        InnerException = "",
                        Message = "Device ID is not valid",
                        StackTrace = "",
                    },
                    Status = "Error"
                };

                return await Task.FromResult(RegistrationResponseError);
            } else if(_UserInfo.FcmToken == "" ^ _UserInfo.FcmToken == null)
            {
                UserRegistrationResponseModel RegistrationResponseError = new UserRegistrationResponseModel
                {
                    Error = new ErrorModel
                    {
                        ErrorCode = "512",
                        InnerException = "",
                        Message = "FCM Token is not valid",
                        StackTrace = "",
                    },
                    Status = "Error"
                };

                return await Task.FromResult(RegistrationResponseError);
            } else if(_UserInfo.RideshareApp == 0 && _UserInfo.CourierApp == 0)
            {
                UserRegistrationResponseModel RegistrationResponseError = new UserRegistrationResponseModel
                {
                    Error = new ErrorModel
                    {
                        ErrorCode = "512",
                        InnerException = "",
                        Message = "Please specify the user app {RideshareApp} or {CourierApp}",
                        StackTrace = "",
                    },
                    Status = "Error"
                };

                return await Task.FromResult(RegistrationResponseError);
            }
            else
            {
                UserRegistrationResponseModel RegistrationResponse = await _UserInfoRepo.RegisterUser(_UserInfo);

                if (RegistrationResponse.Status == "Success")
                {
                    JcdSenderInfo _SenderInfo = new JcdSenderInfo
                    {
                        ActiveStatus = 1,
                        AllowableAddress = 3,
                        RewardPoint = 0,
                        SenderId = RegistrationResponse.LoginInfo.LoginId,
                        SenderType = _UserInfo.SenderType
                    };
                    CommonResponseModel Response = await _SenderInfoRepo.AddNew(_SenderInfo);

                    if (Response.Status == "Success")
                    {
                        return await Task.FromResult(RegistrationResponse);
                    }
                    else
                    {
                        await _UserInfoRepo.RemoveUserInfo(RegistrationResponse.LoginInfo.LoginId);
                        RegistrationResponse.Error = new ErrorModel();
                        RegistrationResponse.Error.ErrorCode = Response.Error.ErrorCode;
                        RegistrationResponse.Error.InnerException = Response.Error.InnerException;
                        RegistrationResponse.Error.Message = Response.Error.Message;
                        RegistrationResponse.Error.StackTrace = Response.Error.StackTrace;
                        RegistrationResponse.LoginInfo = null;
                        RegistrationResponse.Status = "Error";

                        return await Task.FromResult(RegistrationResponse);
                    }
                }
                else
                {
                    return await Task.FromResult(RegistrationResponse);
                }
            }
        }
        public async Task<UserVerificationResponseModel> VerifyUser(UserVerifyModel _UserVerifyModel)
        {
            if(_UserVerifyModel.PhoneNumber.Length < 14 ^ _UserVerifyModel.PhoneNumber.Length > 20)
            {
                UserVerificationResponseModel ResponseModel = new UserVerificationResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "512",
                        InnerException ="",
                        Message = "Phone Number Invalid",
                        StackTrace = ""
                    }
                };

                return await Task.FromResult(ResponseModel);
            } else
            {
                JpxUserLoginInfoRepo _UserInfoRepo = new JpxUserLoginInfoRepo();

                return await _UserInfoRepo.UserVerifyStatus(_UserVerifyModel);
            }
            
        }
        public async Task<PayLoadModel> GetUserProfile(long SenderId)
        {
            JpxUserLoginInfoRepo _UserInfoRepo = new JpxUserLoginInfoRepo();

            UserAuthModel _UserAtuhModel = await _UserInfoRepo.GetUserProfile(SenderId);

            CipherClient _CipherClient = new CipherClient(_UserAtuhModel.DeviceId, _UserAtuhModel.SecretKey);
            string UserProfilePayLoad = JsonConvert.SerializeObject(_UserAtuhModel.UserProfile);
            CipherPayload _CipherPayload = await _CipherClient.EncryptText(UserProfilePayLoad);

            if (_CipherPayload.Status == "Success")
            {
                PayLoadModel _PayloadModel = new PayLoadModel
                {
                    SenderID = SenderId.ToString(),
                    PayLoad = _CipherPayload.PayLoad
                };

                return await Task.FromResult(_PayloadModel);
            }
            else
            {
                PayLoadModel _PayLoadModel = new PayLoadModel
                {
                    SenderID = SenderId.ToString(),
                    PayLoad = JsonConvert.SerializeObject(new ErrorModel
                    {
                        ErrorCode = "511",
                        Message = "Invalid user info or data not found. Please contact with admin.",
                        InnerException = "",
                        StackTrace = ""
                    })
                };
                return await Task.FromResult(_PayLoadModel);
            }
        }
        public async Task<PayLoadModel> UpdateUserProfile(UserUpdatePaylod _UserPayLoad)
        {
            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(_UserPayLoad.SenderID));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);

            CipherPayload _CipherPayload = await _CipherClient.DecryptText(_UserPayLoad.PayLoad);

            if (_CipherPayload.Status == "Success")
            {
                if (_CipherPayload.PayLoad == null)
                {
                    PayLoadModel _PayLoadModel = new PayLoadModel
                    {
                        SenderID = _UserAuth.UserInfo.LoginId.ToString(),
                        PayLoad = JsonConvert.SerializeObject(new ErrorModel
                        {
                            ErrorCode = "511",
                            Message = "Invalid user info or Corrupted Data.",
                            InnerException = "",
                            StackTrace = ""
                        })
                    };
                    return await Task.FromResult(_PayLoadModel);

                }

                UpdateUserModel _UserModel = JsonConvert.DeserializeObject<UpdateUserModel>(_CipherPayload.PayLoad);

                _UserAuth.UserInfo.UserFirstName = _UserModel.UserFirstName;
                _UserAuth.UserInfo.UserLastName = _UserModel.UserLastName;
                _UserAuth.UserInfo.UserEmail = _UserModel.UserEmail;
                if (_UserPayLoad.ProfilePicture != "")
                {
                    _UserAuth.UserInfo.ProfilePicture = _UserPayLoad.ProfilePicture;
                    _UserAuth.UserAuthModel.UserProfile.ProfilePicture = _UserModel.ProfilePicture;
                }

                _UserAuth.UserAuthModel.UserProfile.UserFirstName = _UserModel.UserFirstName;
                _UserAuth.UserAuthModel.UserProfile.UserLastName = _UserModel.UserLastName;
                _UserAuth.UserAuthModel.UserProfile.UserEmail = _UserModel.UserEmail;

                CommonResponseModel _Response = await _UserRepo.UpdateUserInfo(_UserAuth.UserInfo);

                if (_Response.Status == "Success")
                {
                    UserVerificationResponseModel _UserProfile = new UserVerificationResponseModel
                    {
                        UserFirstName = _UserAuth.UserInfo.UserFirstName,
                        UserLastName = _UserAuth.UserInfo.UserLastName,
                        UserEmail = _UserAuth.UserInfo.UserEmail,
                        CourierApp = _UserAuth.UserInfo.CourierApp,
                        RideshareApp = _UserAuth.UserInfo.RideshareApp,
                        ProfilePicture = _UserAuth.UserInfo.ProfilePicture,
                        RegistrationDate = _UserAuth.UserInfo.RegistrationDate,
                        ActiveStatus = _UserAuth.UserInfo.ActiveStatus,
                        DeviceId = _UserAuth.UserInfo.DeviceId,
                        DeviceType = _UserAuth.UserInfo.DeviceType,
                        LoginId = _UserAuth.UserInfo.LoginId,
                        SecretKey = _UserAuth.UserInfo.SecretKey,
                        UserMobileNo = _UserAuth.UserInfo.UserMobileNo,
                        Status = "Success"
                    };
                    CipherPayload _ResponsePayload = await _CipherClient.EncryptText(JsonConvert.SerializeObject(_UserProfile));

                    if (_ResponsePayload.Status == "Success")
                    {
                        PayLoadModel _PayLoadModel = new PayLoadModel
                        {
                            SenderID = _UserAuth.UserInfo.LoginId.ToString(),
                            PayLoad = _ResponsePayload.PayLoad
                        };

                        return await Task.FromResult(_PayLoadModel);
                    }
                    else
                    {
                        PayLoadModel _PayLoadModel = new PayLoadModel
                        {
                            SenderID = _UserAuth.UserInfo.LoginId.ToString(),
                            PayLoad = JsonConvert.SerializeObject(new ErrorModel
                            {
                                ErrorCode = "511",
                                Message = "Invalid user info or data not found. Please contact with admin.",
                                InnerException = "",
                                StackTrace = ""
                            })
                        };
                        return await Task.FromResult(_PayLoadModel);
                    }
                }
                else
                {
                    PayLoadModel _PayloadResponse = new PayLoadModel
                    {
                        SenderID = _UserAuth.UserInfo.LoginId.ToString(),
                        PayLoad = JsonConvert.SerializeObject(_Response.Error)
                    };

                    return await Task.FromResult(_PayloadResponse);
                }
            }
            else
            {
                PayLoadModel _PayLoadModel = new PayLoadModel
                {
                    SenderID = _UserAuth.UserInfo.LoginId.ToString(),
                    PayLoad = JsonConvert.SerializeObject(new ErrorModel
                    {
                        ErrorCode = "511",
                        Message = "Invalid user info or data not found. Please contact with admin.",
                        InnerException = "",
                        StackTrace = ""
                    })
                };
                return await Task.FromResult(_PayLoadModel);
            }
        }
        public async Task<UserAuthModel> GetUserProfileByID(long SenderId)
        {
            JpxUserLoginInfoRepo _UserInfoRepo = new JpxUserLoginInfoRepo();

            return await _UserInfoRepo.GetUserProfileById(SenderId);
        }        
        public async Task<PayLoadModel> GetRomDB(DateTime LatestDate, int ActiveStatus, string SenderId)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;

            JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
            JpxUserLoginInfoModel _UserAuth = await _UserRepo.GetUserById(Convert.ToInt64(SenderId));
            CipherClient _CipherClient = new CipherClient(_UserAuth.UserInfo.DeviceId, _UserAuth.UserInfo.SecretKey);

            RomDbRepo _RomDbRepo = new RomDbRepo();
            RomDbResponse Response = await _RomDbRepo.GetRomDB(LatestDate, ActiveStatus);

            CipherPayload _CipherPayload = await _CipherClient.EncryptText(JsonConvert.SerializeObject(Response));

            if (_CipherPayload.Status == "Success")
            {
                PayLoadModel _PayLoadModel = new PayLoadModel
                {
                    SenderID = SenderId,
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    PayLoad = _CipherPayload.PayLoad
                };

                return await Task.FromResult(_PayLoadModel);
            }
            else
            {
                PayLoadModel _PayLoadModel = new PayLoadModel
                {
                    SenderID = SenderId,
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
                    PayLoad = JsonConvert.SerializeObject(new ErrorModel
                    {
                        ErrorCode = "511",
                        Message = "Invalid user info or data not found. Please contact with admin.",
                        InnerException = "",
                        StackTrace = ""
                    })
                };
                return await Task.FromResult(_PayLoadModel);
            }
        }
    }
}
