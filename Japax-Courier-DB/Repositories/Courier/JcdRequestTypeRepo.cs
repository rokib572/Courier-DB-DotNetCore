using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdRequestTypeRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<RequestTypeModel> GetRequestTypes()
        {
            try
            {
                List<JcdRequestType> Requests = await Context.JcdRequestType.Where(x => x.ActiveStatus == 1).OrderBy(y => y.RequestTypeId).ToListAsync();

                RequestTypeModel Response = new RequestTypeModel
                {
                    Status = "Success",
                    RequestTypes = (from JcdRequestType Reqeust in Requests
                                    select new RequestTypeInfo
                                 {
                                     RequestType = Reqeust.RequestType,
                                     RequestTypeId = Reqeust.RequestTypeId,
                                     ShowToClient = Reqeust.ShowToClient,
                                     ShowToDH = Reqeust.ShowToDh
                                    }).ToList()
                };

                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                RequestTypeModel Response = new RequestTypeModel
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
                    ErrMethodPayload = "GetRequestTypes",
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
