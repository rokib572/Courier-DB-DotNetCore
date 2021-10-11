using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdCustomerFeedback
    {
        public long RequestId { get; set; }
        public long DhId { get; set; }
        public byte EvaluateBy { get; set; }
        public int EvaluationId { get; set; }
        public byte EvaluationRating { get; set; }
        public string OtherEvaluation { get; set; }

        public virtual JcdDeliveryHeroInfo Dh { get; set; }
        public virtual JcdCustomerFeedbackQuestionware Evaluation { get; set; }
        public virtual JcdPickupAndDeliveryRequest Request { get; set; }
    }
}
