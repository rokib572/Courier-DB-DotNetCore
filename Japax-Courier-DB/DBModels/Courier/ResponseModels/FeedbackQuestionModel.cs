using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class FeedbackQuestionModel
    {
        public string Status { get; set; }
        public List<FeedbackQuestionInfo> FeedbackQuestions { get; set; }
        public FeedbackQuestionInfo FeedbackQuestion { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class FeedbackQuestionInfo
    {
        public int EvaluationId { get; set; }
        public int SortingOrder { get; set; }
        public string AspectsOfEvaluation { get; set; }
    }
}
