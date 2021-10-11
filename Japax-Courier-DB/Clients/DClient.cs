using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.Repositories.Courier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.Cipher;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Japax_Courier_DB.Clients
{
    public class DClient
    {
        JpxCourierContext Context = new JpxCourierContext();
        private JcdAssignedRequestRepo AssignRepo = new JcdAssignedRequestRepo();
        private JcdDeliveryHeroInfoRepo DhRepo = new JcdDeliveryHeroInfoRepo();
        private JcdDhLocationStatusRepo DhLocationStatusRepo = new JcdDhLocationStatusRepo();
        private JcdDeliveryHeroInfoRepo DhInfoRepo = new JcdDeliveryHeroInfoRepo();
        public async Task<CommonResponseModel> AddNewDH(DhInfoRequestModel DhInfo)
        {
            try
            {
                var parameters = new[] {
                        new SqlParameter("@OPT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 3 },
                        new SqlParameter("@DhId", SqlDbType.BigInt) { Direction = ParameterDirection.Input, Value = DhInfo.DhId },
                        new SqlParameter("@DhPhone", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhMobNo},
                        new SqlParameter("@P_PAGE_NO", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 1},
                        new SqlParameter("@P_TOT_RECORD_OUT", SqlDbType.Int) { Direction = ParameterDirection.Output},
                        new SqlParameter("@P_RECORD_PER_PAGE", SqlDbType.Int) { Direction = ParameterDirection.Output},
                    };

                DeliveryHero Result = await Task.FromResult(Context.DeliveryHero
                                               .FromSqlRaw($"SP_JCD_GET_DH @OPT_ID, @DhId, @DhPhone, @P_PAGE_NO, " +
                                                           $"@P_TOT_RECORD_OUT OUTPUT, @P_RECORD_PER_PAGE OUTPUT", parameters)
                                               .AsEnumerable()
                                               .FirstOrDefault());

                if(Convert.ToInt32(parameters[4].Value) == 0)
                {
                    JcdDeliveryHeroInfo Info = new JcdDeliveryHeroInfo
                    {
                        ActiveStatus = 1,
                        AreaIdPmt = (byte)DhInfo.AreaIdPmt,
                        AreaIdPr = (byte)DhInfo.AreaIdPr,
                        AssignTeam = DhInfo.AssignTeam,
                        DefaultAssignRole = DhInfo.DefaultAssignRole,
                        DhEmailAddr = DhInfo.DhEmailAddr,
                        PermenantAddress = DhInfo.PermenantAddress,
                        PresentAddress = DhInfo.PresentAddress,
                        DeviceId = DhInfo.DeviceId,
                        DhCode = DhInfo.DhCode,
                        DhFirstName = DhInfo.DhFirstName,
                        DhImage = DhInfo.DhImage,
                        DhLastName = DhInfo.DhLastName,
                        DhMiddleName = DhInfo.DhMiddleName,
                        DhMobNo = DhInfo.DhMobNo,
                        DhNationality = DhInfo.DhNationality,
                        DhNid = DhInfo.DhNid,
                        DhPassword = DhInfo.DhPassword,
                        FcmToken = DhInfo.FcmToken,
                        JoiningDate = DhInfo.JoiningDate,
                        EmergencyMobNo = DhInfo.EmergencyMobNo,
                        HouseNoPmt = DhInfo.HouseNoPmt,
                        HouseNoPr = DhInfo.HouseNoPr,
                        LicencePlate = DhInfo.LicencePlate,
                        LocationPmt = DhInfo.LocationPmt,
                        LocationPr = DhInfo.LocationPr,
                        PostalCodePmt = DhInfo.PostalCodePmt,
                        PostalCodePr = DhInfo.PostalCodePr,
                        PsUpazlaIdPmt = DhInfo.PsUpazlaIdPmt,
                        PsUpazlaIdPr = DhInfo.PsUpazlaIdPr,
                        StreetPmt = DhInfo.StreetPmt,
                        StreetPr = DhInfo.StreetPr,
                        TransportColor = DhInfo.TransportColor,
                        TransportDescription = DhInfo.TransportDescription,
                        TransportType = DhInfo.TransportType,
                        UserId = DhInfo.UserId,
                        SetDate = DateTime.Now
                    };

                    return await DhInfoRepo.AddNewDH(Info);
                } else
                {
                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            StackTrace= "",
                            ErrorCode = "523",
                            InnerException = "",
                            Message = "A Delivery Hero with the Mobile Number already exists."
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
        public async Task<CommonResponseModel> UpdateDH(DhInfoRequestModel DhInfo)
        {
            try
            {
                JcdDeliveryHeroInfo Info = new JcdDeliveryHeroInfo
                {
                    ActiveStatus = 1,
                    AreaIdPmt = (byte)DhInfo.AreaIdPmt,
                    AreaIdPr = (byte)DhInfo.AreaIdPr,
                    AssignTeam = DhInfo.AssignTeam,
                    DefaultAssignRole = DhInfo.DefaultAssignRole,
                    DhEmailAddr = DhInfo.DhEmailAddr,
                    PermenantAddress = DhInfo.PermenantAddress,
                    PresentAddress = DhInfo.PresentAddress,
                    DeviceId = DhInfo.DeviceId,
                    DhCode = DhInfo.DhCode,
                    DhFirstName = DhInfo.DhFirstName,
                    DhImage = DhInfo.DhImage,
                    DhLastName = DhInfo.DhLastName,
                    DhMiddleName = DhInfo.DhMiddleName,
                    DhMobNo = DhInfo.DhMobNo,
                    DhNationality = DhInfo.DhNationality,
                    DhNid = DhInfo.DhNid,
                    DhPassword = DhInfo.DhPassword,
                    FcmToken = DhInfo.FcmToken,
                    JoiningDate = DhInfo.JoiningDate,
                    EmergencyMobNo = DhInfo.EmergencyMobNo,
                    HouseNoPmt = DhInfo.HouseNoPmt,
                    HouseNoPr = DhInfo.HouseNoPr,
                    LicencePlate = DhInfo.LicencePlate,
                    LocationPmt = DhInfo.LocationPmt,
                    LocationPr = DhInfo.LocationPr,
                    PostalCodePmt = DhInfo.PostalCodePmt,
                    PostalCodePr = DhInfo.PostalCodePr,
                    PsUpazlaIdPmt = DhInfo.PsUpazlaIdPmt,
                    PsUpazlaIdPr = DhInfo.PsUpazlaIdPr,
                    StreetPmt = DhInfo.StreetPmt,
                    StreetPr = DhInfo.StreetPr,
                    TransportColor = DhInfo.TransportColor,
                    TransportDescription = DhInfo.TransportDescription,
                    TransportType = DhInfo.TransportType,
                    UserId = DhInfo.UserId,
                    DhId = DhInfo.DhId,
                    SetDate = DateTime.Now
                };

                var parameters = new[] {
                        new SqlParameter("@OPT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 3 },
                        new SqlParameter("@DhId", SqlDbType.BigInt) { Direction = ParameterDirection.Input, Value = DhInfo.DhId },
                        new SqlParameter("@DhPhone", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = DhInfo.DhMobNo},
                        new SqlParameter("@P_PAGE_NO", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 1},
                        new SqlParameter("@P_TOT_RECORD_OUT", SqlDbType.Int) { Direction = ParameterDirection.Output},
                        new SqlParameter("@P_RECORD_PER_PAGE", SqlDbType.Int) { Direction = ParameterDirection.Output},
                    };

                DeliveryHero CurrentDh = await Task.FromResult(Context.DeliveryHero
                                               .FromSqlRaw($"SP_JCD_GET_DH @OPT_ID, @DhId, @DhPhone, @P_PAGE_NO, " +
                                                           $"@P_TOT_RECORD_OUT OUTPUT, @P_RECORD_PER_PAGE OUTPUT", parameters)
                                               .AsEnumerable()
                                               .FirstOrDefault());

                //JcdDeliveryHeroInfo CurrentDh = Context.JcdDeliveryHeroInfo.Where(x => x.DhId == DhInfo.DhId).FirstOrDefault();
                //DeliveryHero CurrentDh = await Task.FromResult(Context.Set<DeliveryHero>()
                //                                         .FromSqlRaw("SP_JCD_GET_DH @OPT_ID =3, @DhId=" + DhInfo.DhId + ", @DhPhone=''" + "")
                //                                         .AsEnumerable()
                //                                         .FirstOrDefault());

                if (DhInfo.DhImage == null)
                {
                    if (CurrentDh.DhImage != null)
                    {
                        Info.DhImage = CurrentDh.DhImage;
                    }
                }

                return await DhInfoRepo.UpdateDH(Info);
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
        public async Task<CommonResponseModel> ActivateDH(long DhId, int UserId)
        {
            try
            {
                return await DhInfoRepo.ActivateDH(DhId, UserId);
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
        public async Task<CommonResponseModel> DeactivateDH(long DhId, int UserId)
        {
            try
            {
                return await DhInfoRepo.DeactivateDH(DhId, UserId);
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
        public async Task<DeliveryHeroInfoResponseModel> GetDHList(int OptId, int PageNumber)
        {
            return await DhRepo.GetDHList(OptId, PageNumber);
        }
        public async Task<DeliveryHeroInfoResponseModel> GetDhById(long DhId)
        {
            return await DhRepo.GetDhById(DhId);
        }
        public async Task<CommonResponseModel> ChangeDHStatus(long DhId, byte Status)
        {
            try
            {
                return await DhInfoRepo.ChangeDHStatus(DhId, Status);
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
        public async Task<CommonResponseModel> UpdateDhLocation(long DhId, decimal Latitude, decimal Longitude)
        {
            try
            {
                await Context.Database.ExecuteSqlRawAsync($"SP_JCD_DH_LAST_LOCATION @P_DH_ID = {DhId}, @P_LATITUDES_DATA ='{Latitude}', " +
                                                          $"@P_LONGITUDES_DATA = {Longitude}");

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success"
                };

                return await Task.FromResult(Response);
            }
            catch(Exception ex)
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
                    ErrMethod = "UpdateDhLocation",
                    ErrMethodPayload = "DHId => " + DhId + " | Latitude => " + Latitude + " | Longitude => " + Longitude,
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
            return await DhRepo.LoginDh(DhPhone, DhPassword, FcmToken, DeviceId);
        }
        public async Task<CommonResponseModel> ChangeDhPassword(string DhPhone, string DhPassword)
        {
            return await DhRepo.ChangeDhPassword(DhPhone, DhPassword);
        }
        public async Task<DhAssignmentResponseModel> GetDhAssignmentDetails(long DhId, byte Condition, byte ByManifest, int PageNumber)
        {
            return await AssignRepo.GetDhAssignmentDetails(DhId, Condition, ByManifest, PageNumber);
        }
        public async Task<CommonResponseModel> UpdateAssignmentStatus(string AssignIds, string RequestIds, int AtcPointId, int AcknowledgeByOut, byte OperationId, int AcknowledgeByIn, long ManifestId)
        {
            return await AssignRepo.UpdateAssignmentStatus(AssignIds, RequestIds, AtcPointId, AcknowledgeByOut, OperationId, AcknowledgeByIn, ManifestId);
        }
    }
}
