using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.Cipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdDeliveryHeroInfoRepo
    {
        JpxCourierContext Context = new JpxCourierContext();
        public async Task<CommonResponseModel> AddNewDH(JcdDeliveryHeroInfo DhInfo)
        {
            try
            {
                CipherClient _CipherClient = new CipherClient();

                CipherPayload _CipherPayload = await _CipherClient.EncryptText(DhInfo.DhPassword);

                if (_CipherPayload.Status == "Success")
                {
                    DhInfo.DhPassword = _CipherPayload.PayLoad;
                    var parameters = new[] {
                        new SqlParameter("@DH_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@DH_CODE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhCode },
                        new SqlParameter("@DH_FIRST_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhFirstName },
                        new SqlParameter("@DH_MIDDLE_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhMiddleName },
                        new SqlParameter("@DH_LAST_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhLastName },
                        new SqlParameter("@DH_MOB_NO", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhMobNo },
                        new SqlParameter("@DH_PASSWORD", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhPassword },
                        new SqlParameter("@DH_TYPE", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = DhInfo.DhType },
                        new SqlParameter("@TRANSPORT_TYPE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.TransportType },
                        new SqlParameter("@TRANSPORT_DESCRIPTION", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.TransportDescription },
                        new SqlParameter("@LICENCE_PLATE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.LicencePlate },
                        new SqlParameter("@TRANSPORT_COLOR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.TransportColor },
                        new SqlParameter("@DH_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = DhInfo.DhStatus },
                        new SqlParameter("@DH_NATIONALITY", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhNationality },
                        new SqlParameter("@DH_NID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhNid },
                        new SqlParameter("@DH_EMAIL_ADDR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhEmailAddr },
                        new SqlParameter("@PERMENANT_ADDRESS", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.PermenantAddress },
                        new SqlParameter("@HOUSE_NO_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.HouseNoPmt },
                        new SqlParameter("@STREET_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.StreetPmt },
                        new SqlParameter("@PS_UPAZLA_ID_PMT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DhInfo.PsUpazlaIdPmt },
                        new SqlParameter("@AREA_ID_PMT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DhInfo.AreaIdPmt },
                        new SqlParameter("@POSTAL_CODE_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.PostalCodePmt },
                        new SqlParameter("@LOCATION_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.LocationPmt },
                        new SqlParameter("@PRESENT_ADDRESS", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.PresentAddress },
                        new SqlParameter("@HOUSE_NO_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.HouseNoPr },
                        new SqlParameter("@STREET_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.StreetPr },
                        new SqlParameter("@PS_UPAZLA_ID_PR", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DhInfo.PsUpazlaIdPr },
                        new SqlParameter("@AREA_ID_PR", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DhInfo.AreaIdPr },
                        new SqlParameter("@POSTAL_CODE_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.PostalCodePr },
                        new SqlParameter("@LOCATION_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.LocationPr },
                        new SqlParameter("@EMERGENCY_MOB_NO", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.EmergencyMobNo },
                        new SqlParameter("@JOINING_DATE", SqlDbType.Date) { Direction = ParameterDirection.Input, Value = DhInfo.JoiningDate },
                        new SqlParameter("@DH_IMAGE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhImage },
                        new SqlParameter("@FCM_TOKEN", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DEVICE_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = DhInfo.ActiveStatus },
                        new SqlParameter("@USER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DhInfo.UserId },
                        new SqlParameter("@OPT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = 'I' }
                    };

                    await Context.Database.ExecuteSqlRawAsync("SP_JCD_DH_OPERATION @DH_ID, @DH_CODE, @DH_FIRST_NAME, " +
                                                                "@DH_MIDDLE_NAME, @DH_LAST_NAME, @DH_MOB_NO, @DH_PASSWORD, @DH_TYPE, " +
                                                                "@TRANSPORT_TYPE, @TRANSPORT_DESCRIPTION, @LICENCE_PLATE, @TRANSPORT_COLOR, " +
                                                                "@DH_STATUS, @DH_NATIONALITY, @DH_NID, @DH_EMAIL_ADDR, @PERMENANT_ADDRESS, " +
                                                                "@HOUSE_NO_PMT, @STREET_PMT, @PS_UPAZLA_ID_PMT, @AREA_ID_PMT, @POSTAL_CODE_PMT, " +
                                                                "@LOCATION_PMT, @PRESENT_ADDRESS, @HOUSE_NO_PR, @STREET_PR, @PS_UPAZLA_ID_PR, " +
                                                                "@AREA_ID_PR, @POSTAL_CODE_PR, @LOCATION_PR, @EMERGENCY_MOB_NO, @JOINING_DATE, " +
                                                                "@DH_IMAGE, @FCM_TOKEN, @DEVICE_ID, @ACTIVE_STATUS, @USER_ID, @OPT_ID", parameters);


                    //await Context.JcdDeliveryHeroInfo.AddAsync(DhInfo);
                    //await Context.SaveChangesAsync();

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
                            ErrorCode = "519",
                            InnerException = "",
                            Message = "Bad or Corrupted user data.",
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
                    ErrMethodPayload = "AddNewDH",
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
        public async Task<CommonResponseModel> UpdateDH(JcdDeliveryHeroInfo DhInfo)
        {
            try
            {
                CipherClient _CipherClient = new CipherClient();

                CipherPayload _CipherPayload = await _CipherClient.EncryptText(DhInfo.DhPassword);

                if (_CipherPayload.Status == "Success")
                {
                    DhInfo.DhPassword = _CipherPayload.PayLoad;
                    var parameters = new[] {
                        new SqlParameter("@DH_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhId },
                        new SqlParameter("@DH_CODE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhCode },
                        new SqlParameter("@DH_FIRST_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhFirstName },
                        new SqlParameter("@DH_MIDDLE_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhMiddleName },
                        new SqlParameter("@DH_LAST_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhLastName },
                        new SqlParameter("@DH_MOB_NO", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhMobNo },
                        new SqlParameter("@DH_PASSWORD", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_TYPE", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = DhInfo.DhType },
                        new SqlParameter("@TRANSPORT_TYPE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.TransportType },
                        new SqlParameter("@TRANSPORT_DESCRIPTION", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.TransportDescription },
                        new SqlParameter("@LICENCE_PLATE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.LicencePlate },
                        new SqlParameter("@TRANSPORT_COLOR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.TransportColor },
                        new SqlParameter("@DH_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = DhInfo.DhStatus },
                        new SqlParameter("@DH_NATIONALITY", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhNationality },
                        new SqlParameter("@DH_NID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhNid },
                        new SqlParameter("@DH_EMAIL_ADDR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhEmailAddr },
                        new SqlParameter("@PERMENANT_ADDRESS", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.PermenantAddress },
                        new SqlParameter("@HOUSE_NO_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.HouseNoPmt },
                        new SqlParameter("@STREET_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.StreetPmt },
                        new SqlParameter("@PS_UPAZLA_ID_PMT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DhInfo.PsUpazlaIdPmt },
                        new SqlParameter("@AREA_ID_PMT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DhInfo.AreaIdPmt },
                        new SqlParameter("@POSTAL_CODE_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.PostalCodePmt },
                        new SqlParameter("@LOCATION_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.LocationPmt },
                        new SqlParameter("@PRESENT_ADDRESS", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.PresentAddress },
                        new SqlParameter("@HOUSE_NO_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.HouseNoPr },
                        new SqlParameter("@STREET_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.StreetPr },
                        new SqlParameter("@PS_UPAZLA_ID_PR", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DhInfo.PsUpazlaIdPr },
                        new SqlParameter("@AREA_ID_PR", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DhInfo.AreaIdPr },
                        new SqlParameter("@POSTAL_CODE_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.PostalCodePr },
                        new SqlParameter("@LOCATION_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.LocationPr },
                        new SqlParameter("@EMERGENCY_MOB_NO", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.EmergencyMobNo },
                        new SqlParameter("@JOINING_DATE", SqlDbType.Date) { Direction = ParameterDirection.Input, Value = DhInfo.JoiningDate },
                        new SqlParameter("@DH_IMAGE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhImage },
                        new SqlParameter("@FCM_TOKEN", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DEVICE_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = DhInfo.ActiveStatus },
                        new SqlParameter("@USER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = DhInfo.UserId },
                        new SqlParameter("@OPT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = 'U' }
                    };

                    await Context.Database.ExecuteSqlRawAsync("SP_JCD_DH_OPERATION @DH_ID, @DH_CODE, @DH_FIRST_NAME, " +
                                                                "@DH_MIDDLE_NAME, @DH_LAST_NAME, @DH_MOB_NO, @DH_PASSWORD, @DH_TYPE, " +
                                                                "@TRANSPORT_TYPE, @TRANSPORT_DESCRIPTION, @LICENCE_PLATE, @TRANSPORT_COLOR, " +
                                                                "@DH_STATUS, @DH_NATIONALITY, @DH_NID, @DH_EMAIL_ADDR, @PERMENANT_ADDRESS, " +
                                                                "@HOUSE_NO_PMT, @STREET_PMT, @PS_UPAZLA_ID_PMT, @AREA_ID_PMT, @POSTAL_CODE_PMT, " +
                                                                "@LOCATION_PMT, @PRESENT_ADDRESS, @HOUSE_NO_PR, @STREET_PR, @PS_UPAZLA_ID_PR, " +
                                                                "@AREA_ID_PR, @POSTAL_CODE_PR, @LOCATION_PR, @EMERGENCY_MOB_NO, @JOINING_DATE, " +
                                                                "@DH_IMAGE, @FCM_TOKEN, @DEVICE_ID, @ACTIVE_STATUS, @USER_ID, @OPT_ID", parameters);


                    //await Context.JcdDeliveryHeroInfo.AddAsync(DhInfo);
                    //await Context.SaveChangesAsync();

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
                            ErrorCode = "519",
                            InnerException = "",
                            Message = "Bad or Corrupted user data.",
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
                    ErrMethodPayload = "UpdateDH",
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
        public async Task<CommonResponseModel> DeactivateDH(long DhId, int UserId)
        {
            try
            {
                var parameters = new[] {
                        new SqlParameter("@DH_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhId },
                        new SqlParameter("@DH_CODE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_FIRST_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_MIDDLE_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_LAST_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_MOB_NO", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_PASSWORD", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_TYPE", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@TRANSPORT_TYPE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@TRANSPORT_DESCRIPTION", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@LICENCE_PLATE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@TRANSPORT_COLOR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 1 },
                        new SqlParameter("@DH_NATIONALITY", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_NID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_EMAIL_ADDR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@PERMENANT_ADDRESS", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@HOUSE_NO_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@STREET_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@PS_UPAZLA_ID_PMT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 1 },
                        new SqlParameter("@AREA_ID_PMT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 1 },
                        new SqlParameter("@POSTAL_CODE_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@LOCATION_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@PRESENT_ADDRESS", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@HOUSE_NO_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@STREET_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@PS_UPAZLA_ID_PR", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 1 },
                        new SqlParameter("@AREA_ID_PR", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 1 },
                        new SqlParameter("@POSTAL_CODE_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@LOCATION_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@EMERGENCY_MOB_NO", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@JOINING_DATE", SqlDbType.Date) { Direction = ParameterDirection.Input, Value = "1900-01-01" },
                        new SqlParameter("@DH_IMAGE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@FCM_TOKEN", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DEVICE_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@USER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = UserId },
                        new SqlParameter("@OPT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = 'D' }
                    };

                    await Context.Database.ExecuteSqlRawAsync("SP_JCD_DH_OPERATION @DH_ID, @DH_CODE, @DH_FIRST_NAME, " +
                                                                "@DH_MIDDLE_NAME, @DH_LAST_NAME, @DH_MOB_NO, @DH_PASSWORD, @DH_TYPE, " +
                                                                "@TRANSPORT_TYPE, @TRANSPORT_DESCRIPTION, @LICENCE_PLATE, @TRANSPORT_COLOR, " +
                                                                "@DH_STATUS, @DH_NATIONALITY, @DH_NID, @DH_EMAIL_ADDR, @PERMENANT_ADDRESS, " +
                                                                "@HOUSE_NO_PMT, @STREET_PMT, @PS_UPAZLA_ID_PMT, @AREA_ID_PMT, @POSTAL_CODE_PMT, " +
                                                                "@LOCATION_PMT, @PRESENT_ADDRESS, @HOUSE_NO_PR, @STREET_PR, @PS_UPAZLA_ID_PR, " +
                                                                "@AREA_ID_PR, @POSTAL_CODE_PR, @LOCATION_PR, @EMERGENCY_MOB_NO, @JOINING_DATE, " +
                                                                "@DH_IMAGE, @FCM_TOKEN, @DEVICE_ID, @ACTIVE_STATUS, @USER_ID, @OPT_ID", parameters);

                //await Context.SaveChangesAsync();

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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "DeactivateDH",
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
        public async Task<CommonResponseModel> ActivateDH(long DhId, int UserId)
        {
            try
            {
                var parameters = new[] {
                        new SqlParameter("@DH_ID", SqlDbType.BigInt) { Direction = ParameterDirection.Input, Value = DhId },
                        new SqlParameter("@DH_CODE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_FIRST_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_MIDDLE_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_LAST_NAME", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_MOB_NO", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_PASSWORD", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_TYPE", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@TRANSPORT_TYPE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@TRANSPORT_DESCRIPTION", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@LICENCE_PLATE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@TRANSPORT_COLOR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 1 },
                        new SqlParameter("@DH_NATIONALITY", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_NID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DH_EMAIL_ADDR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@PERMENANT_ADDRESS", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@HOUSE_NO_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@STREET_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@PS_UPAZLA_ID_PMT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 1 },
                        new SqlParameter("@AREA_ID_PMT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 1 },
                        new SqlParameter("@POSTAL_CODE_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@LOCATION_PMT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@PRESENT_ADDRESS", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@HOUSE_NO_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@STREET_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@PS_UPAZLA_ID_PR", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 1 },
                        new SqlParameter("@AREA_ID_PR", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 1 },
                        new SqlParameter("@POSTAL_CODE_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@LOCATION_PR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@EMERGENCY_MOB_NO", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@JOINING_DATE", SqlDbType.Date) { Direction = ParameterDirection.Input, Value = "1900-01-01" },
                        new SqlParameter("@DH_IMAGE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@FCM_TOKEN", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@DEVICE_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = "" },
                        new SqlParameter("@ACTIVE_STATUS", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@USER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = UserId },
                        new SqlParameter("@OPT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = 'A' }
                    };

                await Context.Database.ExecuteSqlRawAsync("SP_JCD_DH_OPERATION @DH_ID, @DH_CODE, @DH_FIRST_NAME, " +
                                                            "@DH_MIDDLE_NAME, @DH_LAST_NAME, @DH_MOB_NO, @DH_PASSWORD, @DH_TYPE, " +
                                                            "@TRANSPORT_TYPE, @TRANSPORT_DESCRIPTION, @LICENCE_PLATE, @TRANSPORT_COLOR, " +
                                                            "@DH_STATUS, @DH_NATIONALITY, @DH_NID, @DH_EMAIL_ADDR, @PERMENANT_ADDRESS, " +
                                                            "@HOUSE_NO_PMT, @STREET_PMT, @PS_UPAZLA_ID_PMT, @AREA_ID_PMT, @POSTAL_CODE_PMT, " +
                                                            "@LOCATION_PMT, @PRESENT_ADDRESS, @HOUSE_NO_PR, @STREET_PR, @PS_UPAZLA_ID_PR, " +
                                                            "@AREA_ID_PR, @POSTAL_CODE_PR, @LOCATION_PR, @EMERGENCY_MOB_NO, @JOINING_DATE, " +
                                                            "@DH_IMAGE, @FCM_TOKEN, @DEVICE_ID, @ACTIVE_STATUS, @USER_ID, @OPT_ID", parameters);

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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "ActivateDH",
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
        public async Task<DeliveryHeroInfoResponseModel> GetDHList(int OptId, int PageNumber)
        {
            //OptId >> 1 = All | 2 = Active Only
            try
            {
                var parameters = new[] {
                        new SqlParameter("@OPT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = OptId },
                        new SqlParameter("@DhId", SqlDbType.BigInt) { Direction = ParameterDirection.Input, Value = 0 },
                        new SqlParameter("@DhPhone", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = ""},
                        new SqlParameter("@P_PAGE_NO", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = PageNumber},
                        new SqlParameter("@P_TOT_RECORD_OUT", SqlDbType.Int) { Direction = ParameterDirection.Output},
                        new SqlParameter("@P_RECORD_PER_PAGE", SqlDbType.Int) { Direction = ParameterDirection.Output},
                    };

                List<DeliveryHeroInfo> Result = await Context.DeliveryHeroInfo
                                               .FromSqlRaw($"SP_JCD_GET_DH @OPT_ID, @DhId, @DhPhone, @P_PAGE_NO, " +
                                                           $"@P_TOT_RECORD_OUT OUTPUT, @P_RECORD_PER_PAGE OUTPUT", parameters)
                                               .ToListAsync();                

                if(Result.Count > 0)
                {
                    double TotalResults = Convert.ToInt64(parameters[4].Value);
                    int RecordPerPage = Convert.ToInt32(parameters[5].Value);

                    double TotalPage = Math.Ceiling((TotalResults / RecordPerPage));

                    bool HasNextPage = false;

                    if (TotalPage > PageNumber)
                    {
                        HasNextPage = true;
                    }

                    DeliveryHeroInfoResponseModel Response = new DeliveryHeroInfoResponseModel
                    {
                        Status = "Success",
                        DeliveryHeroInfo = Result,
                        Pagination= new Pagination {
                            TotalPage = TotalPage,
                            CurrentPage = PageNumber,
                            HasNextPage = HasNextPage
                        }                        
                    };
                    return await Task.FromResult(Response);
                } else
                {
                    DeliveryHeroInfoResponseModel Response = new DeliveryHeroInfoResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "522",
                            InnerException = "",
                            Message = "No Records found.",
                            StackTrace = ""
                        }
                    };
                    return await Task.FromResult(Response);
                }
            } catch (Exception ex)
            {
                DeliveryHeroInfoResponseModel Response = new DeliveryHeroInfoResponseModel
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
                    ErrMethod = "GetDHList",
                    ErrMethodPayload = "OptId => " + OptId,
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
        public async Task<CommonResponseModel> ChangeDHStatus(long DhId, byte Status)
        {
            try
            {
                var CurrentDH = await Context.JcdDeliveryHeroInfo.Where(x => x.DhId == DhId).FirstOrDefaultAsync();
                CurrentDH.DhStatus = Status;

                await Context.SaveChangesAsync();

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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "ChangeDHStatus",
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
        public async Task<CommonResponseModel> UpdateCurrentLocation(long DhId, decimal Latitude, decimal Longitude)
        {
            try
            {
                var CurrentDh = await Context.JcdDeliveryHeroInfo.Where(x => x.DhId == DhId).FirstOrDefaultAsync();

                CurrentDh.LatitudesData = Latitude;
                CurrentDh.LongitudesData = Longitude;

                await Context.SaveChangesAsync();

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
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "UpdateCurrentLocation",
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
        public async Task<DeliveryHeroInfoResponseModel> GetDhById(long DhId)
        {
            try
            {
                var parameters = new[] {
                        new SqlParameter("@OPT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 3 },
                        new SqlParameter("@DhId", SqlDbType.BigInt) { Direction = ParameterDirection.Input, Value = DhId },
                        new SqlParameter("@DhPhone", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = ""},
                        new SqlParameter("@P_PAGE_NO", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 1},
                        new SqlParameter("@P_TOT_RECORD_OUT", SqlDbType.Int) { Direction = ParameterDirection.Output},
                        new SqlParameter("@P_RECORD_PER_PAGE", SqlDbType.Int) { Direction = ParameterDirection.Output},
                    };

                DeliveryHero Result = await Task.FromResult(Context.DeliveryHero
                                               .FromSqlRaw($"SP_JCD_GET_DH @OPT_ID, @DhId, @DhPhone, @P_PAGE_NO, " +
                                                           $"@P_TOT_RECORD_OUT OUTPUT, @P_RECORD_PER_PAGE OUTPUT", parameters)
                                               .AsEnumerable()
                                               .FirstOrDefault());

                if (Result !=null)
                {
                    DeliveryHeroInfoResponseModel Response = new DeliveryHeroInfoResponseModel
                    {
                        Status = "Success",                      
                        DeliveryHero = Result
                    };

                    return await Task.FromResult(Response);
                } else
                {
                    DeliveryHeroInfoResponseModel Response = new DeliveryHeroInfoResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "522",
                            InnerException = "",
                            Message = "No Records found.",
                            StackTrace = ""
                        }
                    };
                    return await Task.FromResult(Response);
                }
            } catch (Exception ex)
            {
                DeliveryHeroInfoResponseModel Response = new DeliveryHeroInfoResponseModel
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
                    ErrMethod = "GetDhById",
                    ErrMethodPayload = "DhId => " + DhId,
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
        public async Task<JcdDeliveryHeroInfo> GetActiveDhById(long DhId)
        {
            return await Context.JcdDeliveryHeroInfo.Where(x => x.DhId == DhId && x.ActiveStatus == 1).FirstOrDefaultAsync();
        }
        public async Task<JcdDeliveryHeroInfo> GetDhByPhone(string DhPhone)
        {
            return await Context.JcdDeliveryHeroInfo.Where(x => x.DhMobNo == DhPhone).FirstOrDefaultAsync();
        }
        public async Task<CommonResponseModel> UpdatePassword(string DhPhone, string DhPassword)
        {
            try
            {
                JcdDeliveryHeroInfo DhInfo = await Context.JcdDeliveryHeroInfo.Where(x => x.DhMobNo == DhPhone).FirstOrDefaultAsync();
                DhInfo.DhPassword = DhPassword;
                await Context.SaveChangesAsync();

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
                    ErrMethodPayload = "UpdatePassword",
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
        public async Task<DhProfileResponseModel> UpdatePhoneProps(long DhId, string FcmToken, string DeviceId)
        {
            try
            {
                JcdDeliveryHeroInfo DhInfo = await Context.JcdDeliveryHeroInfo.Where(x => x.DhId == DhId).FirstOrDefaultAsync();

                DhInfo.FcmToken = FcmToken;
                DhInfo.DeviceId = DeviceId;

                await Context.SaveChangesAsync();

                DhProfileResponseModel Response = new DhProfileResponseModel
                {
                    Status = "Success",
                    DhInfo = new DhInfoModel
                    {
                        AssignTeam = DhInfo.AssignTeam,
                        DefaultAssignRole = DhInfo.DefaultAssignRole,
                        DhEmailAddr = DhInfo.DhEmailAddr,
                        DeviceId = DhInfo.DeviceId,
                        DhCode = DhInfo.DhCode,
                        DhFirstName = DhInfo.DhFirstName,
                        DhId = DhInfo.DhId,
                        DhImage = DhInfo.DhImage,
                        DhLastName = DhInfo.DhLastName,
                        DhMiddleName = DhInfo.DhMiddleName,
                        DhMobNo = DhInfo.DhMobNo,
                        DhType = DhInfo.DhType,
                        FcmToken = DhInfo.FcmToken,
                        JoiningDate = DhInfo.JoiningDate,
                        LicencePlate = DhInfo.LicencePlate,
                        TransportColor = DhInfo.TransportColor,
                        TransportDescription = DhInfo.TransportDescription,
                        TransportType = DhInfo.TransportType
                    }
                };

                return await Task.FromResult(Response);
            } catch (Exception ex)
            {
                DhProfileResponseModel Response = new DhProfileResponseModel
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
                    ErrMethodPayload = "UpdatePhoneProps",
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
        public async Task<DhProfileResponseModel> LoginDh(string DhPhone, string DhPassword, string FcmToken, string DeviceId)
        {
            CipherClient _CipherClient = new CipherClient();

            JcdDeliveryHeroInfo DhInfo = await GetDhByPhone(DhPhone);

            if (DhInfo != null)
            {
                if (DhInfo.ActiveStatus == 0)
                {
                    DhProfileResponseModel Response = new DhProfileResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "518",
                            InnerException = "",
                            Message = "Your account is inactive. Please contact with administrator.",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    CipherPayload _CipherPayload = await _CipherClient.DecryptText(DhInfo.DhPassword);
                    if (_CipherPayload.Status == "Success")
                    {
                        if (_CipherPayload.PayLoad == DhPassword)
                        {
                            DhProfileResponseModel Response = await UpdatePhoneProps(DhInfo.DhId, FcmToken, DeviceId);

                            return await Task.FromResult(Response);
                        }
                        else
                        {
                            DhProfileResponseModel Response = new DhProfileResponseModel
                            {
                                Status = "Error",
                                Error = new ErrorModel
                                {
                                    ErrorCode = "518",
                                    InnerException = "",
                                    Message = "Password wrong.",
                                    StackTrace = ""
                                }
                            };

                            return await Task.FromResult(Response);
                        }
                    }
                    else
                    {
                        DhProfileResponseModel Response = new DhProfileResponseModel
                        {
                            Status = "Error",
                            Error = new ErrorModel
                            {
                                ErrorCode = "518",
                                InnerException = "",
                                Message = "Bad User Data found.",
                                StackTrace = ""
                            }
                        };

                        return await Task.FromResult(Response);
                    }
                }
            }
            else
            {
                DhProfileResponseModel Response = new DhProfileResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "518",
                        InnerException = "",
                        Message = "Account not found.",
                        StackTrace = ""
                    }
                };

                return await Task.FromResult(Response);
            }
        }
        public async Task<CommonResponseModel> ChangeDhPassword(string DhPhone, string DhPassword)
        {
            CipherClient _CipherClient = new CipherClient();

            JcdDeliveryHeroInfo DhInfo = await GetDhByPhone(DhPhone);

            if(DhInfo != null)
            {
                if (DhInfo.ActiveStatus == 0)
                {
                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "518",
                            InnerException = "",
                            Message = "Account is inactive. Please activate the account first.",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                } else
                {
                    CipherPayload _CipherPayload = await _CipherClient.EncryptText(DhPassword);
                    if (_CipherPayload.Status == "Success")
                    {
                        return await UpdatePassword(DhPhone, _CipherPayload.PayLoad);
                    }
                    else
                    {
                        CommonResponseModel Response = new CommonResponseModel
                        {
                            Status = "Error",
                            Error = new ErrorModel
                            {
                                ErrorCode = "518",
                                InnerException = "",
                                Message = "Bad User Data found.",
                                StackTrace = ""
                            }
                        };

                        return await Task.FromResult(Response);
                    }
                }
            } else
            {
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        ErrorCode = "518",
                        InnerException = "",
                        Message = "Account not found.",
                        StackTrace = ""
                    }
                };

                return await Task.FromResult(Response);
            }
        }
    }
}
