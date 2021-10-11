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
    public class JcdGiftWrappingChargeRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<GiftWrappingChargeResponseModel> GetGiftWrappingById(int GiftWrappingId)
        {
            try
            {
                JcdGiftWrappingCharge Wrapping = await Context.JcdGiftWrappingCharge.Where(x => x.GiftWrappingId == GiftWrappingId).FirstOrDefaultAsync();
                GiftWrappingChargeResponseModel Response = new GiftWrappingChargeResponseModel
                {
                    Status = "Success",
                    GiftWrappingId = Wrapping.GiftWrappingId,
                    WrappingCharge = Wrapping.WrappingCharge,
                    WrappingType = Wrapping.WrappingType
                };
                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                GiftWrappingChargeResponseModel Response = new GiftWrappingChargeResponseModel
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
                    ErrMethodPayload = "GetGiftWrappingById => GiftWrappingId = " + GiftWrappingId,
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
