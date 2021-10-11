using Japax_Courier_DB.DBModels.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Auth.Models;
using Japax_Courier_DB.DBModels.Auth.Models.Response;
using Newtonsoft.Json;
using Japax_Courier_DB.DBModels.Auth.Models.Request;
using System.Reflection;
using System.Diagnostics;
using Japax_Courier_DB.DBModels.Courier;

namespace Japax_Courier_DB.Repositories.Auth
{
    public class JpxUserLoginInfoRepo
    {
        JpxAuthContext _Context = new JpxAuthContext();
        JpxCourierContext CourierContext = new JpxCourierContext();

        public async Task<CommonResponseModel> AddUserInfo(JpxUserLoginInfo _LoginInfo)
        {
            try
            {
                await _Context.JpxUserLoginInfo.AddAsync(_LoginInfo);
                await _Context.SaveChangesAsync();
                CommonResponseModel ResponseModel = new CommonResponseModel
                {
                    Status = "Success"
                };
                return await Task.FromResult(ResponseModel);
            }
            catch (DbUpdateException ex)
            {
                CommonResponseModel ResponseModel = new CommonResponseModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = JsonConvert.SerializeObject(_LoginInfo),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = _LoginInfo.LoginId
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(ResponseModel);
            }
        }
        public async Task<CommonResponseModel> RemoveUserInfo(long LoginId)
        {
            try
            {
                JpxUserLoginInfo UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.LoginId == LoginId).FirstOrDefaultAsync();
                _Context.JpxUserLoginInfo.Remove(UserInfo);
                await _Context.SaveChangesAsync();
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
                JpxErrorLogRepo _LogRepo = new JpxErrorLogRepo();
                JpxErrorLog _ErrorLog = new JpxErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "UserID: " + LoginId,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = LoginId
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(Response);
            }
        }
        public async Task<CommonResponseModel> UpdateUserInfo(JpxUserLoginInfo _LoginInfo)
        {
            try
            {
                //JpxUserLoginInfo _UserInfo = _Context.JpxUserLoginInfo.Where(x => x.LoginId == _LoginInfo.LoginId).FirstOrDefault();

                _Context.Update(_LoginInfo);
                await _Context.SaveChangesAsync();
                CommonResponseModel ResponseModel = new CommonResponseModel
                {
                    Status = "Success"
                };
                return await Task.FromResult(ResponseModel);
            }
            catch (Exception ex)
            {
                //Send Notification to user
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = JsonConvert.SerializeObject(_LoginInfo),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = _LoginInfo.LoginId
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(Response);
            }

        }
        public async Task<JpxUserLoginInfoModel> GetUserById(long userId)
        {
            try
            {
                JpxUserLoginInfo UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.LoginId == userId).FirstOrDefaultAsync();
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
                {
                    Status = "Success",
                    UserInfo = UserInfo,
                    UserAuthModel = new UserAuthModel
                    {
                        DeviceId = UserInfo.DeviceId,
                        FCMKey = UserInfo.FcmToken,
                        PhoneNumber = UserInfo.UserMobileNo,
                        SecretKey = UserInfo.SecretKey,
                        UserId = UserInfo.LoginId,
                        UserProfile = new UserProfileModel
                        {
                            ActiveStatus = UserInfo.ActiveStatus,
                            CourierApp = UserInfo.CourierApp,
                            RideshareApp = UserInfo.RideshareApp,
                            UserEmail = UserInfo.UserEmail,
                            ProfilePicture = UserInfo.ProfilePicture,
                            RegistrationDate = UserInfo.RegistrationDate,
                            Status = "Success",
                            UserFirstName = UserInfo.UserFirstName,
                            UserLastName = UserInfo.UserLastName
                        }
                    }
                };
                return await Task.FromResult(UserInfoModel);
            }
            catch (Exception ex)
            {
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "UserId: " + userId,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = userId
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(UserInfoModel);
            }
        }
        public async Task<JpxUserLoginInfoModel> GetUserByPhone(string userPhoneNumber)
        {
            try
            {
                JpxUserLoginInfo UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.UserMobileNo == userPhoneNumber).FirstOrDefaultAsync();

                if (UserInfo == null)
                {
                    JpxUserLoginInfoModel UserInfoModelError = new JpxUserLoginInfoModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "505",
                            InnerException = "",
                            Message = "User Phone Number Doesnot Exists",
                            StackTrace = ""
                        }
                    };
                    return await Task.FromResult(UserInfoModelError);

                }

                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
                {
                    Status = "Success",
                    UserInfo = UserInfo,
                    UserAuthModel = new UserAuthModel
                    {
                        DeviceId = UserInfo.DeviceId,
                        FCMKey = UserInfo.FcmToken,
                        PhoneNumber = UserInfo.UserMobileNo,
                        SecretKey = UserInfo.SecretKey,
                        UserId = UserInfo.LoginId,
                        UserProfile = new UserProfileModel
                        {
                            ActiveStatus = UserInfo.ActiveStatus,
                            CourierApp = UserInfo.CourierApp,
                            RideshareApp = UserInfo.RideshareApp,
                            UserEmail = UserInfo.UserEmail,
                            ProfilePicture = UserInfo.ProfilePicture,
                            RegistrationDate = UserInfo.RegistrationDate,
                            Status = "Success",
                            UserFirstName = UserInfo.UserFirstName,
                            UserLastName = UserInfo.UserLastName
                        }
                    }
                };
                return await Task.FromResult(UserInfoModel);
            }
            catch (Exception ex)
            {
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "Phone: " + userPhoneNumber,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(UserInfoModel);
            }
        }
        public async Task<JpxUserLoginInfoModel> GetUserByDeviceId(string deviceId)
        {
            try
            {
                JpxUserLoginInfo UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.DeviceId == deviceId).FirstOrDefaultAsync();
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
                {
                    Status = "Success",
                    UserInfo = UserInfo
                };
                return await Task.FromResult(UserInfoModel);
            }
            catch (Exception ex)
            {
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "DeviceId: " + deviceId,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(UserInfoModel);
            }
        }
        public async Task<JpxUserLoginInfoModel> GetUserByFCMToken(string fcmToken)
        {
            try
            {
                JpxUserLoginInfo UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.FcmToken == fcmToken).FirstOrDefaultAsync();
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
                {
                    Status = "Success",
                    UserInfo = UserInfo
                };
                return await Task.FromResult(UserInfoModel);
            }
            catch (Exception ex)
            {
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "FCM Token: " + fcmToken,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(UserInfoModel);
            }
        }
        public async Task<JpxUserLoginInfoModel> GetUserBySecret(string secretKey)
        {
            try
            {
                JpxUserLoginInfo UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.SecretKey == secretKey).FirstOrDefaultAsync();
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
                {
                    Status = "Success",
                    UserInfo = UserInfo
                };
                return await Task.FromResult(UserInfoModel);
            }
            catch (Exception ex)
            {
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "Secret Key: " + secretKey,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(UserInfoModel);
            }
        }
        public async Task<JpxUserLoginInfoModel> GetUserByDeviceType(byte DeviceType)
        {
            //0=Android | 1=iOS
            try
            {
                List<JpxUserLoginInfo> UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.DeviceType == DeviceType).ToListAsync();
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
                {
                    Status = "Success",
                    UserInfoList = UserInfo
                };
                return await Task.FromResult(UserInfoModel);
            }
            catch (Exception ex)
            {
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "Device Type: " + DeviceType,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(UserInfoModel);
            }
        }
        public async Task<JpxUserLoginInfoModel> GetActiveUsers()
        {
            try
            {
                List<JpxUserLoginInfo> UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.ActiveStatus == 1).ToListAsync();
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
                {
                    Status = "Success",
                    UserInfoList = UserInfo
                };
                return await Task.FromResult(UserInfoModel);
            }
            catch (Exception ex)
            {
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "GetActiveUser",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(UserInfoModel);
            }
        }
        public async Task<JpxUserLoginInfoModel> GetRideShareUsers()
        {
            try
            {
                List<JpxUserLoginInfo> UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.RideshareApp == 1).ToListAsync();
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
                {
                    Status = "Success",
                    UserInfoList = UserInfo
                };
                return await Task.FromResult(UserInfoModel);
            }
            catch (Exception ex)
            {
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "GetRideShareUsers",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(UserInfoModel);
            }
        }
        public async Task<JpxUserLoginInfoModel> GetCourierUsers()
        {
            try
            {
                List<JpxUserLoginInfo> UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.CourierApp == 1).ToListAsync();
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
                {
                    Status = "Success",
                    UserInfoList = UserInfo
                };
                return await Task.FromResult(UserInfoModel);
            }
            catch (Exception ex)
            {
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "GetCourierUsers",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(UserInfoModel);
            }
        }
        public async Task<JpxUserLoginInfoModel> GetActiveRideShareUsers()
        {
            try
            {
                List<JpxUserLoginInfo> UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.RideshareApp == 1 && x.ActiveStatus == 1).ToListAsync();
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
                {
                    Status = "Success",
                    UserInfoList = UserInfo
                };
                return await Task.FromResult(UserInfoModel);
            }
            catch (Exception ex)
            {
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "GetActiveRideShareUsers",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(UserInfoModel);
            }
        }
        public async Task<JpxUserLoginInfoModel> GetActiveCouriersers()
        {
            try
            {
                List<JpxUserLoginInfo> UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.CourierApp == 1 && x.ActiveStatus == 1).ToListAsync();
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
                {
                    Status = "Success",
                    UserInfoList = UserInfo
                };
                return await Task.FromResult(UserInfoModel);
            }
            catch (Exception ex)
            {
                JpxUserLoginInfoModel UserInfoModel = new JpxUserLoginInfoModel
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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "GetActiveCouriersers",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(UserInfoModel);
            }
        }
        public async Task<UserVerificationResponseModel> UserVerifyStatus(UserVerifyModel _UserVerifyModel)
        {
            try
            {
                JpxUserLoginInfoRepo _UserRepo = new JpxUserLoginInfoRepo();
                JpxUserLoginInfo _User = await _Context.JpxUserLoginInfo.Where(x => x.UserMobileNo == _UserVerifyModel.PhoneNumber).FirstOrDefaultAsync();
                JcdSenderInfo _SenderInfo = null;

                if (_User != null)
                {
                    _SenderInfo = await CourierContext.JcdSenderInfo.Where(x => x.SenderId == _User.LoginId).FirstOrDefaultAsync();
                    //Updte Device ID
                    if (_UserVerifyModel.DeviceId != null)
                    {
                        if(_UserVerifyModel.DeviceId != "")
                        {
                            _User.DeviceId = _UserVerifyModel.DeviceId;
                        }
                    }
                    
                    if(_UserVerifyModel.FCMToken != null)
                    {
                        if(_UserVerifyModel.FCMToken != "")
                        {
                            _User.FcmToken = _UserVerifyModel.FCMToken;
                        }                        
                    }

                    _User.DeviceType = _UserVerifyModel.DeviceType;
                    
                    if (_UserVerifyModel.CourierApp == 1)
                    {
                        _User.CourierApp = _UserVerifyModel.CourierApp;
                    }

                    if (_UserVerifyModel.RideshareApp == 1)
                    {
                        _User.RideshareApp = _UserVerifyModel.RideshareApp;
                    }

                    //result = await _UserRepo.UpdateUserInfo(_User);
                    await _Context.SaveChangesAsync();

                    UserVerificationResponseModel _UserModel = new UserVerificationResponseModel
                    {
                        Status = "Success",
                        ActiveStatus = _User.ActiveStatus,
                        DeviceId = _User.DeviceId,
                        DeviceType = _User.DeviceType,
                        LoginId = _User.LoginId,
                        ProfilePicture = _User.ProfilePicture,
                        RegistrationDate = _User.RegistrationDate,
                        UserFirstName = _User.UserFirstName,
                        UserLastName = _User.UserLastName,
                        UserMobileNo = _User.UserMobileNo,
                        UserEmail = _User.UserEmail,
                        CourierApp = _User.CourierApp,
                        RideshareApp = _User.RideshareApp,
                        SecretKey = _User.SecretKey,
                        SenderType = _SenderInfo.SenderType
                    };
                    return await Task.FromResult(_UserModel);
                }
                else
                {
                    UserVerificationResponseModel _UserModel = new UserVerificationResponseModel
                    {
                        Status = "Not Registered"
                    };
                    return await Task.FromResult(_UserModel);
                }
            }
            catch (Exception ex)
            {
                //Something Went Wrong
                //Write Log


                //write log end
                //Send User Notification
                UserVerificationResponseModel _UserModel = new UserVerificationResponseModel
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
                    ErrMethod = "UserVerifyStatus",
                    ErrMethodPayload = JsonConvert.SerializeObject(_UserVerifyModel),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_UserModel);
            }
        }
        public async Task<UserRegistrationResponseModel> RegisterUser(UserInfoModel _UserInfo)
        {
            try
            {
                string guId = Guid.NewGuid().ToString();
                byte[] guIdByte = System.Text.Encoding.UTF8.GetBytes(guId);
                string guIdBase64 = System.Convert.ToBase64String(guIdByte);
                string secretKey = guIdBase64.Substring(0, 16);

                JpxUserLoginInfoModel _CheckUser = await GetUserByPhone(_UserInfo.UserMobileNo);

                if (_CheckUser.UserInfo != null)
                {
                    UserRegistrationResponseModel _RegistrationResponse = new UserRegistrationResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "510",
                            Message = "User Already Registered.",
                            InnerException = "",
                            StackTrace = ""
                        }
                    };
                    return await Task.FromResult(_RegistrationResponse);
                }
                else
                {
                    JpxUserLoginInfo _UserLoginInfo = new JpxUserLoginInfo
                    {
                        ActiveStatus = 1,
                        CourierApp = _UserInfo.CourierApp,
                        RideshareApp = _UserInfo.RideshareApp,
                        DeviceId = _UserInfo.DeviceId,
                        DeviceType = _UserInfo.DeviceType,
                        FcmToken = _UserInfo.FcmToken,
                        ProfilePicture = "",
                        RegistrationDate = DateTime.Now.ToLocalTime(),
                        SecretKey = secretKey,
                        SetDate = DateTime.Now.ToLocalTime(),
                        UserEmail = _UserInfo.UserEmail,
                        UserFirstName = _UserInfo.UserFirstName,
                        UserLastName = _UserInfo.UserLastName,
                        UserMobileNo = _UserInfo.UserMobileNo
                    };
                    _Context.JpxUserLoginInfo.Add(_UserLoginInfo);
                    await _Context.SaveChangesAsync();

                    UserRegistrationResponseModel _RegistrationResponse = new UserRegistrationResponseModel
                    {
                        Status = "Success",
                        LoginInfo = _UserLoginInfo
                    };
                    return await Task.FromResult(_RegistrationResponse);
                }
            }
            catch (Exception ex)
            {
                UserRegistrationResponseModel _RegistrationResponse = new UserRegistrationResponseModel
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
                StackTrace stackTrace = new StackTrace();
                StackFrame stackFrame = stackTrace.GetFrame(1);

                JpxErrorLog _ErrorLog = new JpxErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "RegisterUser",
                    ErrMethodPayload = JsonConvert.SerializeObject(_UserInfo),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_RegistrationResponse);
            }
        }
        public async Task<UserAuthModel> GetUserProfile(long SenderId)
        {
            try
            {
                JpxUserLoginInfo _UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.LoginId == SenderId).FirstOrDefaultAsync();
                JcdSenderInfo _SenderInfo = await CourierContext.JcdSenderInfo.Where(x => x.SenderId == SenderId).FirstOrDefaultAsync();

                if (_UserInfo != null)
                {
                    if (_UserInfo.ActiveStatus == 0)
                    {
                        UserAuthModel _UserAuthModel = new UserAuthModel
                        {
                            UserId = _UserInfo.LoginId,
                            DeviceId = _UserInfo.DeviceId,
                            FCMKey = _UserInfo.FcmToken,
                            PhoneNumber = _UserInfo.UserMobileNo,
                            SecretKey = _UserInfo.SecretKey,
                            UserProfile = new UserProfileModel
                            {
                                Status = "Error",
                                Error = new ErrorModel
                                {
                                    ErrorCode = "506",
                                    Message = "Your account disabled, please contact with our customer support for details."
                                }
                            }
                        };
                        return await Task.FromResult(_UserAuthModel);
                    }
                    else
                    {
                        UserAuthModel _UserAuthModel = new UserAuthModel
                        {
                            UserId = _UserInfo.LoginId,
                            DeviceId = _UserInfo.DeviceId,
                            FCMKey = _UserInfo.FcmToken,
                            PhoneNumber = _UserInfo.UserMobileNo,
                            SecretKey = _UserInfo.SecretKey,
                            UserProfile = new UserProfileModel
                            {
                                Status = "Success",
                                ActiveStatus = _UserInfo.ActiveStatus,
                                CourierApp = _UserInfo.CourierApp,
                                RideshareApp = _UserInfo.RideshareApp,
                                UserEmail = _UserInfo.UserEmail,
                                ProfilePicture = _UserInfo.ProfilePicture,
                                RegistrationDate = _UserInfo.RegistrationDate,
                                UserFirstName = _UserInfo.UserFirstName,
                                UserLastName = _UserInfo.UserLastName,
                                SenderType = _SenderInfo.SenderType
                            }
                        };
                        return await Task.FromResult(_UserAuthModel);
                    }
                }
                else
                {
                    UserAuthModel _UserAuthModel = new UserAuthModel
                    {
                        UserId = _UserInfo.LoginId,
                        DeviceId = _UserInfo.DeviceId,
                        FCMKey = _UserInfo.FcmToken,
                        PhoneNumber = _UserInfo.UserMobileNo,
                        SecretKey = _UserInfo.SecretKey,
                        UserProfile = new UserProfileModel
                        {
                            Status = "Error",
                            Error = new ErrorModel
                            {
                                ErrorCode = "507",
                                Message = "User not found!"
                            }
                        }
                    };
                    return await Task.FromResult(_UserAuthModel);
                }
            }
            catch (Exception ex)
            {
                //Something Went Wrong
                //Write Log
                //write log end
                //Send User Notification

                UserAuthModel _UserAuthModel = new UserAuthModel
                {
                    UserProfile = new UserProfileModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "505",
                            InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                            Message = (ex.Message != null) ? ex.Message.ToString() : "",
                            StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                        }
                    }
                };
                //<<<<<Start Register Log>>>>>
                JpxErrorLogRepo _LogRepo = new JpxErrorLogRepo();
                JpxErrorLog _ErrorLog = new JpxErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "GetUserProfile",
                    ErrMethodPayload = "Device ID: " + SenderId.ToString(),
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_UserAuthModel);
            }
        }
        public async Task<UserAuthModel> GetUserProfileById(long SenderId)
        {
            try
            {
                JpxUserLoginInfo _UserInfo = await _Context.JpxUserLoginInfo.Where(x => x.LoginId == SenderId).FirstOrDefaultAsync();
                JcdSenderInfo _SenderInfo = await CourierContext.JcdSenderInfo.Where(x => x.SenderId == SenderId).FirstOrDefaultAsync();

                if (_UserInfo != null)
                {
                    if (_UserInfo.ActiveStatus == 0)
                    {
                        UserAuthModel _UserAuthModel = new UserAuthModel
                        {
                            UserId = _UserInfo.LoginId,
                            DeviceId = _UserInfo.DeviceId,
                            FCMKey = _UserInfo.FcmToken,
                            PhoneNumber = _UserInfo.UserMobileNo,
                            SecretKey = _UserInfo.SecretKey,
                            UserProfile = new UserProfileModel
                            {
                                Status = "Error",
                                Error = new ErrorModel
                                {
                                    ErrorCode = "506",
                                    Message = "Your account disabled, please contact with our customer support for details."
                                }
                            }
                        };
                        return await Task.FromResult(_UserAuthModel);
                    }
                    else
                    {
                        UserAuthModel _UserAuthModel = new UserAuthModel
                        {
                            UserId = _UserInfo.LoginId,
                            DeviceId = _UserInfo.DeviceId,
                            FCMKey = _UserInfo.FcmToken,
                            PhoneNumber = _UserInfo.UserMobileNo,
                            SecretKey = _UserInfo.SecretKey,
                            UserProfile = new UserProfileModel
                            {
                                Status = "Success",
                                ActiveStatus = _UserInfo.ActiveStatus,
                                CourierApp = _UserInfo.CourierApp,
                                RideshareApp = _UserInfo.RideshareApp,
                                UserEmail = _UserInfo.UserEmail,
                                ProfilePicture = _UserInfo.ProfilePicture,
                                RegistrationDate = _UserInfo.RegistrationDate,
                                UserFirstName = _UserInfo.UserFirstName,
                                UserLastName = _UserInfo.UserLastName,
                                SenderType = _SenderInfo.SenderType
                            }
                        };
                        return await Task.FromResult(_UserAuthModel);
                    }
                }
                else
                {
                    UserAuthModel _UserAuthModel = new UserAuthModel
                    {
                        UserId = _UserInfo.LoginId,
                        DeviceId = _UserInfo.DeviceId,
                        FCMKey = _UserInfo.FcmToken,
                        PhoneNumber = _UserInfo.UserMobileNo,
                        SecretKey = _UserInfo.SecretKey,
                        UserProfile = new UserProfileModel
                        {
                            Status = "Error",
                            Error = new ErrorModel
                            {
                                ErrorCode = "507",
                                Message = "User not found!"
                            }
                        }
                    };
                    return await Task.FromResult(_UserAuthModel);
                }
            }
            catch (Exception ex)
            {
                //Something Went Wrong
                //Write Log


                //write log end
                //Send User Notification

                UserAuthModel _UserAuthModel = new UserAuthModel
                {
                    UserProfile = new UserProfileModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "505",
                            InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                            Message = (ex.Message != null) ? ex.Message.ToString() : "",
                            StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                        }
                    }
                };
                //<<<<<Start Register Log>>>>>
                JpxErrorLogRepo _LogRepo = new JpxErrorLogRepo();
                JpxErrorLog _ErrorLog = new JpxErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = "GetUserProfileById",
                    ErrMethodPayload = "User ID: " + SenderId,
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = SenderId
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>

                return await Task.FromResult(_UserAuthModel);
            }
        }
        public async Task<UserRegistrationResponseModel> AddNewUser(MerchantRegistrationRequestModel Request)
        {
            try
            {
                JpxUserLoginInfoModel _CheckUser = await GetUserByPhone(Request.RepresentativeMobileNo);

                if (_CheckUser.UserAuthModel != null)
                {
                    //User Already Exists
                    UserRegistrationResponseModel Response = new UserRegistrationResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "533",
                            InnerException = "",
                            Message = "User already exits.",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    JpxUserLoginInfo LoginInfo = new JpxUserLoginInfo
                    {
                        UserMobileNo = Request.RepresentativeMobileNo,
                        UserFirstName = Request.RepresentativeFirstName,
                        UserLastName = Request.RepresentativeLastName,
                        UserEmail = Request.RepresentativeEmail,
                        RideshareApp = Request.RideshareApp,
                        CourierApp = Request.CourierApp,
                        DeviceId = Request.DeviceId,
                        DeviceType = Request.DeviceType,
                        FcmToken = Request.FcmToken,
                        ProfilePicture = Request.CompanyLogo,
                        //RegistrationDate = Request.RegistrationDate,
                        SecretKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())).Substring(0, 16),
                        ActiveStatus = 1,
                        SetDate = DateTime.Now
                    };

                    _Context.JpxUserLoginInfo.Add(LoginInfo);
                    await _Context.SaveChangesAsync();

                    UserRegistrationResponseModel Response = new UserRegistrationResponseModel
                    {
                        Status = "Success",
                        LoginInfo = LoginInfo
                    };

                    return await Task.FromResult(Response);
                }
            } catch(Exception ex)
            {
                UserRegistrationResponseModel Response = new UserRegistrationResponseModel
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
                    ErrMethod = "AddNewUser",
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
