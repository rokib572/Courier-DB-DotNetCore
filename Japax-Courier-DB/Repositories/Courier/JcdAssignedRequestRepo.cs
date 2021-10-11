using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.RequestModels;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Japax_Courier_DB.FcmMessaging;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdAssignedRequestRepo
    {
        JpxCourierContext _Context = new JpxCourierContext();
        JcdNotificationSmsMasterRepo notificationSmsRepo = new JcdNotificationSmsMasterRepo();
        //Private double PageSize = 10;
        public async Task<JcdAssignRequest> GetByRequestId(long RequestId)
        {
            return await _Context.JcdAssignRequest.Where(x => x.RequestId == RequestId).FirstOrDefaultAsync();
        }
        public async Task<List<JcdAssignRequest>> GetListByRequestId(long RequestId)
        {
            return await _Context.JcdAssignRequest.Where(x => x.RequestId == RequestId).ToListAsync();
        }
        public async Task<CommonResponseModel> AssignRequestToDh(AssignRequestModel AssignRequest)
        {
            try
            {
                string RequestIds = string.Join<long>(",", AssignRequest.RequestIds);

                var parameters = new[] {
                        new SqlParameter("@P_REQUEST_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestIds },
                        new SqlParameter("@P_DH_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = AssignRequest.DhId },
                        new SqlParameter("@P_MANIFEST_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = AssignRequest.ManifestId },
                        new SqlParameter("@P_ASSIGN_FOR", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = AssignRequest.AssignFor },
                        new SqlParameter("@P_ASSIGN_BY", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = AssignRequest.AssignBy },
                        new SqlParameter("@P_PICKUP_POINT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = AssignRequest.PickupPointId },
                        new SqlParameter("@P_DROP_POINT_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = AssignRequest.DropPointId },
                    };

                await _Context.Database.ExecuteSqlRawAsync("SP_JCD_ASSIGN_REQUEST_TO_DH @P_REQUEST_ID, @P_DH_ID, @P_MANIFEST_ID," +
                                                            "@P_ASSIGN_FOR, @P_ASSIGN_BY, @P_PICKUP_POINT_ID, @P_DROP_POINT_ID"
                                                            , parameters);

                await notificationSmsRepo.SendNotification(AssignRequest.AssignFor, AssignRequest.DhId, AssignRequest.RequestIds);

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
                    ErrMethodPayload = "AssignDhToRequest",
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
        public async Task<DhAssignmentResponseModel> GetDhAssignmentDetails(long DhId, byte Condition, byte ByManifest, int PageNumber)
        {
            try
            {
                var parameters = new[] {
                        new SqlParameter("@P_DH_ID", SqlDbType.BigInt) { Direction = ParameterDirection.Input, Value = DhId },
                        new SqlParameter("@P_SHOW_DATA", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = Condition },
                        new SqlParameter("@P_PAGE_NO", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = PageNumber },
                        new SqlParameter("@P_BY_MANIFEST", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = ByManifest },
                        new SqlParameter("@P_TOT_RECORD_OUT", SqlDbType.BigInt) { Direction = ParameterDirection.Output},
                        new SqlParameter("@P_RECORD_PER_PAGE", SqlDbType.Int) { Direction = ParameterDirection.Output}
                    };

                List<DhAssignmentResponseInfo> Result = await _Context.DhAssignmentResponseInfo
                                                                .FromSqlRaw($"SP_JCD_GET_ASSIGNED_REQUEST_TO_DH @P_DH_ID, @P_SHOW_DATA, " +
                                                                            $"@P_BY_MANIFEST, @P_PAGE_NO, @P_TOT_RECORD_OUT OUTPUT, @P_RECORD_PER_PAGE OUT", parameters)
                                                                .ToListAsync();
                
                if (Result.Count >0)
                {
                    double TotalRecord = Convert.ToInt64(parameters[3].Value);
                    double RecordPerPage = Convert.ToDouble(parameters[4].Value);

                    double TotalPage = Math.Ceiling((TotalRecord / RecordPerPage));
                    bool HasNextPage = false;

                    if (TotalPage > PageNumber)
                    {
                        HasNextPage = true;
                    }

                    DhAssignmentResponseModel Response = new DhAssignmentResponseModel
                    {
                        Status = "Success",
                        AssignmentInfo = Result,
                        Pagination = new Pagination
                        {
                            CurrentPage = PageNumber,
                            HasNextPage = HasNextPage,
                            TotalPage = TotalPage
                        }
                    };
                    return await Task.FromResult(Response);
                } else
                {
                    DhAssignmentResponseModel Response = new DhAssignmentResponseModel
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
            }
            catch (Exception ex)
            {
                DhAssignmentResponseModel Response = new DhAssignmentResponseModel
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
                    ErrMethodPayload = "GetDhAssignmentDetails",
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
        public async Task<CommonResponseModel> UpdateAssignmentStatus(string AssignIds, string RequestIds, int AtcPointId, int AcknowledgeByOut, byte OperationId, int AcknowledgeByIn, long ManifestId)
        {
            //Get Start Time
            DateTime StartTime = DateTime.Now;
            try
            {
                var parameters = new[] {
                        new SqlParameter("@P_ASSIGN_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = AssignIds },
                        new SqlParameter("@P_REQUEST_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = RequestIds },
                        new SqlParameter("@P_ATC_POINT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = AtcPointId },
                        new SqlParameter("@P_ACKNOWLEDGE_BY_OUT", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = AcknowledgeByOut },
                        new SqlParameter("@P_ACKNOWLEDGE_BY_IN", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = AcknowledgeByIn },
                        new SqlParameter("@P_MANIFEST_ID", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = ManifestId },
                        new SqlParameter("@P_OPERATION", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = OperationId },
                        new SqlParameter("@P_NOTIFICATION_ID", SqlDbType.TinyInt) { Direction = ParameterDirection.Output}
                    };

                await _Context.Database.ExecuteSqlRawAsync("SP_JCD_PICKUP_AND_DELIVERY_LOG @P_ASSIGN_ID, @P_ACKNOWLEDGE_BY_IN, " +
                                                            "@P_REQUEST_ID, @P_ATC_POINT_ID, @P_ACKNOWLEDGE_BY_OUT, @P_MANIFEST_ID, @P_OPERATION, " +
                                                            "@P_NOTIFICATION_ID OUTPUT"
                                                            , parameters);


                if(parameters[7] !=null)
                {
                    byte NotificationId = Convert.ToByte(parameters[7].Value);

                    if (AssignIds != "")
                    {
                        List<AssignmentInfoForNotificationModel> AssignmentDetails = _Context.AssignmentInfoForNotificationModel
                                                                                             .FromSqlRaw($"SP_JCD_GET_ASSIGN_DETAILS_FOR_NOTIFICATION " +
                                                                                                         $"@P_OPT_ID = 'A', @P_ASSIGN_IDS = '{AssignIds}'")
                                                                                             .ToList();
                        List<long> requestIds = new List<long>();
                        foreach (AssignmentInfoForNotificationModel assignDetails in AssignmentDetails)
                        {
                            requestIds.Add(assignDetails.RequestId);
                        }

                        await notificationSmsRepo.SendNotification(NotificationId, AssignmentDetails[0].DhId, requestIds);
                    } else
                    {
                        List<AssignmentInfoForNotificationModel> AssignmentDetails = _Context.AssignmentInfoForNotificationModel
                                                                                             .FromSqlRaw($"SP_JCD_GET_ASSIGN_DETAILS_FOR_NOTIFICATION " +
                                                                                                         $"@P_OPT_ID = 'R', @P_REQUEST_IDS = '{RequestIds}'")
                                                                                             .ToList();

                        List<long> requestIds = new List<long>();
                        foreach (AssignmentInfoForNotificationModel assignDetails in AssignmentDetails)
                        {
                            requestIds.Add(assignDetails.RequestId);
                        }

                        await notificationSmsRepo.SendNotification(NotificationId, AssignmentDetails[0].DhId, requestIds);
                    }                  
                }

                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Success",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms"
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                CommonResponseModel Response = new CommonResponseModel
                {
                    Status = "Error",
                    ExecutionTime = (DateTime.Now - StartTime).TotalMilliseconds.ToString() + " ms",
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
                    ErrMethod = "pdateAssignmentStatus",
                    ErrMethodPayload = "Assign Ids => " + AssignIds + " | Request Ids => " + RequestIds + " | ATC Point Id => " + AtcPointId + " | Operation ID => " + OperationId + " | Acknowledged By In => " + AcknowledgeByIn + " | Acknowledged By Out" + AcknowledgeByOut + " | Manifest Id => " + ManifestId,
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
        public async Task<RequestListForAssignmentResponse> GetRequestForAssignment(int AtcPointId, int PageNumber, string Operation)
        {
            var parameters = new[] {
                        new SqlParameter("@P_ATC_POINT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = AtcPointId },
                        new SqlParameter("@P_PAGE_NO", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = PageNumber },
                        new SqlParameter("@P_OPT", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = Operation },
                        new SqlParameter("@P_TOT_RECORD_OUT", SqlDbType.BigInt) { Direction = ParameterDirection.Output},
                        new SqlParameter("@P_RECORD_PER_PAGE", SqlDbType.Int) { Direction = ParameterDirection.Output},
                    };

            List<RequestListForAssignment> Result = await _Context.RequestListForAssignment
                                                            .FromSqlRaw($"SP_JCD_GET_REQUEST_FOR_ASSIGN @P_ATC_POINT_ID, " +
                                                                        $"@P_PAGE_NO, @P_OPT, @P_TOT_RECORD_OUT OUTPUT, " +
                                                                        $"@P_RECORD_PER_PAGE OUTPUT",
                                                                        parameters)
                                                            .ToListAsync();           

            if (Result.Count > 0)
            {
                double TotalRecord = Convert.ToDouble(parameters[3].Value);
                double RecordPerPage = Convert.ToDouble(parameters[4].Value);

                double TotalPage = Math.Ceiling((TotalRecord / RecordPerPage));
                bool HasNextPage = false;

                if (TotalPage > PageNumber)
                {
                    HasNextPage = true;
                }

                RequestListForAssignmentResponse Response = new RequestListForAssignmentResponse
                {
                    Status = "Success",
                    CurrentPage = PageNumber,
                    TotalPage = TotalPage,
                    HasNexPage = HasNextPage,
                    RequestList = Result
                };

                return await Task.FromResult(Response);
            } else
            {
                RequestListForAssignmentResponse Response = new RequestListForAssignmentResponse
                {
                    Status = "Error",
                    Error = new ErrorModel
                    {
                        StackTrace = "",
                        ErrorCode = "522",
                        InnerException = "",
                        Message = "No record found."
                    }
                };
                return await Task.FromResult(Response);
            }
        }
        public async Task<DhAssignmentResponseModel> GetAssignmentByLatestStatus(long DhId, byte NotId, int PageNumber)
        {
            try
            {
                var parameters = new[] {
                        new SqlParameter("@P_DH_ID", SqlDbType.BigInt) { Direction = ParameterDirection.Input, Value = DhId },
                        new SqlParameter("@P_LAST_NOTIFICATION_ID", SqlDbType.TinyInt) { Direction = ParameterDirection.Input, Value = NotId },
                        new SqlParameter("@P_PAGE_NO", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = PageNumber },
                        new SqlParameter("@P_TOT_RECORD_OUT", SqlDbType.BigInt) { Direction = ParameterDirection.Output},
                        new SqlParameter("@P_RECORD_PER_PAGE", SqlDbType.Int) { Direction = ParameterDirection.Output}
                    };

                List<DhAssignmentResponseInfo> Result = await _Context.DhAssignmentResponseInfo
                                                                .FromSqlRaw($"SP_JCD_GET_REQUEST_BY_LAST_STATUS @P_DH_ID, @P_LAST_NOTIFICATION_ID," +
                                                                            $"@P_PAGE_NO, @P_TOT_RECORD_OUT OUT, @P_RECORD_PER_PAGE OUT", parameters)
                                                                .ToListAsync();

                if (Result.Count > 0)
                {
                    double TotalRecord = Convert.ToInt64(parameters[3].Value);
                    double RecordPerPage = Convert.ToDouble(parameters[4].Value);

                    double TotalPage = Math.Ceiling((TotalRecord / RecordPerPage));
                    bool HasNextPage = false;

                    if (TotalPage > PageNumber)
                    {
                        HasNextPage = true;
                    }

                    DhAssignmentResponseModel Response = new DhAssignmentResponseModel
                    {
                        Status = "Success",
                        AssignmentInfo = Result,
                        Pagination = new Pagination
                        {
                            CurrentPage = PageNumber,
                            HasNextPage = HasNextPage,
                            TotalPage = TotalPage
                        }
                    };

                    return await Task.FromResult(Response);
                }
                else
                {
                    DhAssignmentResponseModel Response = new DhAssignmentResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "521",
                            InnerException = "",
                            Message = "No Record Found",
                            StackTrace = ""
                        }
                    };
                    return await Task.FromResult(Response);
                }
            } catch (Exception ex)
            {
                DhAssignmentResponseModel Response = new DhAssignmentResponseModel
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
                    ErrMethod = "GetAssignmentByLatestStatus",
                    ErrMethodPayload = "DhId => " + DhId + ", NotId => " + NotId + ", PageNumber => " + PageNumber,
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
        public async Task<CommonResponseModel> RevokeAssignment(long RequestId)
        {
            try
            {
                List<JcdAssignRequest> AssignmentList = await _Context.JcdAssignRequest.Where(x => x.RequestId == RequestId).ToListAsync();
                if(AssignmentList.Count >0)
                {
                    _Context.JcdAssignRequest.RemoveRange(AssignmentList);
                    await _Context.SaveChangesAsync();

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
                            ErrorCode ="519",
                            InnerException = "",
                            Message = "No Assignment found for this request.",
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
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "RevokeAssignment",
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
        public async Task<CommonResponseModel> OverrideAssignment (AssignRequestModel OverrideRequest)
        {
            try
            {
                JcdAssignRequest CurrentRequest = await _Context.JcdAssignRequest.Where(x => x.RequestId == OverrideRequest.RequestIds[0] && x.AssignFor == OverrideRequest.AssignFor).FirstOrDefaultAsync();

                if (CurrentRequest != null)
                {
                    if (CurrentRequest.AssignFor == 1 ^ CurrentRequest.AssignFor == 2)
                    {
                        if (CurrentRequest.PickupTime.ToString() == DateTime.Parse("1900-01-01").ToString())
                        {
                            CurrentRequest.AcceptDate = DateTime.Parse("1900-01-01");
                            CurrentRequest.AcceptStatus = 0;
                            CurrentRequest.AssignBy = OverrideRequest.AssignBy;
                            CurrentRequest.AssignDate = DateTime.Now;
                            CurrentRequest.DhId = OverrideRequest.DhId;

                            await _Context.SaveChangesAsync();

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
                                    ErrorCode = "520",
                                    InnerException = "",
                                    Message = "Request cannot be override. Package pickup completed.",
                                    StackTrace = ""
                                }
                            };

                            return await Task.FromResult(Response);
                        }
                    }
                    else
                    {
                        if (CurrentRequest.DeliveredTime.ToString() == DateTime.Parse("1900-01-01").ToString())
                        {
                            CurrentRequest.AcceptDate = DateTime.Parse("1900-01-01");
                            CurrentRequest.AcceptStatus = 0;
                            CurrentRequest.AssignBy = OverrideRequest.AssignBy;
                            CurrentRequest.AssignDate = DateTime.Now;
                            CurrentRequest.DhId = OverrideRequest.DhId;

                            await _Context.SaveChangesAsync();

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
                                    ErrorCode = "520",
                                    InnerException = "",
                                    Message = "Request cannot be override. Package pickup delivered.",
                                    StackTrace = ""
                                }
                            };

                            return await Task.FromResult(Response);
                        }
                    }
                }
                else
                {
                    CommonResponseModel Response = new CommonResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "520",
                            InnerException = "",
                            Message = "Assignment not found.",
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
                JcdErrorLogRepo _LogRepo = new JcdErrorLogRepo();
                JcdErrorLog _ErrorLog = new JcdErrorLog
                {
                    ErrEntity = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrInnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                    ErrMessage = (ex.Message != null) ? ex.Message.ToString() : "",
                    ErrMethod = (ex.TargetSite != null) ? ex.TargetSite.Name.ToString() : "",
                    ErrMethodPayload = "OverrideAssignment",
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
