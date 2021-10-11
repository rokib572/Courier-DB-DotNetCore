using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class FeedbackQuestionaireInfoModel
    {
        public string Status { get; set; }
        public List<FeedbackQuestionaireInfo> Questinaires { get; set; }
        public FeedbackQuestionaireInfo Questionaire { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class FeedbackQuestionaireInfo
    {
        public int EvaluationId { get; set; }
        public string AspectsOfEvaluation { get; set; }
        public byte EvaluationMethod { get; set; }
        public byte? EvaluationFor { get; set; }
    }
}
