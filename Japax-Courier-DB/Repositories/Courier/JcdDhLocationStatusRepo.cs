using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Japax_Courier_DB.DBModels.Courier;
using Microsoft.EntityFrameworkCore;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdDhLocationStatusRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<CommonResponseModel> AddDhLocation(JcdDhLocationStatus DhLocation)
        {
            try
            {
                await Context.JcdDhLocationStatus.AddAsync(DhLocation);

                var CurrentDh = await Context.JcdDeliveryHeroInfo.Where(x => x.DhId == DhLocation.DhId).FirstOrDefaultAsync();

                CurrentDh.LatitudesData = DhLocation.LatitudesData;
                CurrentDh.LongitudesData = DhLocation.LongitudesData;

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
                    ErrMethodPayload = "AddDhLocation",
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
