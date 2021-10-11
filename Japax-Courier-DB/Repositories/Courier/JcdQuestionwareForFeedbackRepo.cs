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
    public class JcdQuestionwareForFeedbackRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<FeedbackQuestionaireInfoModel> GetFeedbackQuestionaire()
        {
            try
            {
                List<JcdQuestionwareForFeedback> Qustanaire = await Context.JcdQuestionwareForFeedback.Where(x => x.EvaluationStatus == 1).OrderBy(y => y.EvaluationId).ToListAsync();
                FeedbackQuestionaireInfoModel Response = new FeedbackQuestionaireInfoModel
                {
                    Status = "Success",
                    Questinaires = (from JcdQuestionwareForFeedback Questions in Qustanaire
                              select new FeedbackQuestionaireInfo
                              {
                                  AspectsOfEvaluation = Questions.AspectsOfEvaluation,
                                  EvaluationFor = Questions.EvaluationFor,
                                  EvaluationId = Questions.EvaluationId,
                                  EvaluationMethod = Questions.EvaluationMethod
                              }
                             ).ToList()
                };
                return await Task.FromResult(Response);
            }
            catch (Exception ex)
            {
                FeedbackQuestionaireInfoModel _CityDistrictModel = new FeedbackQuestionaireInfoModel
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
                    ErrMethodPayload = "GetFeedbackQuestionaire",
                    ErrProcedure = (ex.Source != null) ? ex.Source.ToString() : "",
                    ErrRaisedDate = DateTime.Now,
                    ErrStackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : "",
                    UserId = 0
                };
                await _LogRepo.AddLog(_ErrorLog);
                //<<<<<End Register Log>>>>>
                return await Task.FromResult(_CityDistrictModel);
            }
        }
    }
}
