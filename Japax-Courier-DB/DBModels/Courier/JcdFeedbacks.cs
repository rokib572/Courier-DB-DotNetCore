using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdFeedbacks
    {
        public long RequestId { get; set; }
        public byte EvaluateBy { get; set; }
        public int EvaluationId { get; set; }
        public byte EvaluationRating { get; set; }
        public string OtherEvaluation { get; set; }

        public virtual JcdQuestionwareForFeedback Evaluation { get; set; }
        public virtual JcdPickupAndDeliveryRequest Request { get; set; }
    }
}
