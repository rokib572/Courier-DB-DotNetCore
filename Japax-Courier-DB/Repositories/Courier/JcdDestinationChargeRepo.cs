using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Courier;
using Microsoft.EntityFrameworkCore;
using Japax_Courier_DB.DBModels.Courier.ResponseModels;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdDestinationChargeRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<DestinationChargeResponseModel> GetChargeById(int DestinationId)
        {
            try
            {
                List<JcdDestinationCharge> Charge = await Context.JcdDestinationCharge.Where
                    (x => 
                        x.DestinationType == DestinationId && 
                        x.ActiveStatus == 1)
                    .ToListAsync();

                if(Charge != null)
                {
                    DestinationChargeResponseModel Response = new DestinationChargeResponseModel
                    {
                        Status = "Success",
                        DestinationChargeInfo = (from JcdDestinationCharge DestinationCharge in Charge
                                                    select new DestinationChargeInfo
                                                    {
                                                        DeliverySlotsId = DestinationCharge.DeliverySlotsId,
                                                        DestinationCharge = DestinationCharge.DestinationCharge,
                                                        DestinationId = DestinationCharge.DestinationId,
                                                        DestinationType = DestinationCharge.DestinationType
                                                    }
                                                 ).ToList()
                    };

                    return await Task.FromResult(Response);
                } else
                {
                    DestinationChargeResponseModel Response = new DestinationChargeResponseModel
                    {
                        Status = "Error",
                        Error = new ErrorModel
                        {
                            ErrorCode = "524",
                            InnerException = "",
                            Message = "Record Not Found",
                            StackTrace = ""
                        }
                    };

                    return await Task.FromResult(Response);
                }
            } catch (Exception ex)
            {
                DestinationChargeResponseModel Response = new DestinationChargeResponseModel
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
                    ErrMethodPayload = "GetChargeById -> DestinationId = " + DestinationId,
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
