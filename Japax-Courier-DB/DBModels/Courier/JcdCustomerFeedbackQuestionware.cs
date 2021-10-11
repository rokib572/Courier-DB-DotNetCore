using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdCustomerFeedbackQuestionware
    {
        public JcdCustomerFeedbackQuestionware()
        {
            JcdCustomerFeedback = new HashSet<JcdCustomerFeedback>();
        }

        public int EvaluationId { get; set; }
        public byte SortingOrder { get; set; }
        public string AspectsOfEvaluation { get; set; }
        public byte EvaluationMethod { get; set; }
        public byte EvaluationStatus { get; set; }

        public virtual ICollection<JcdCustomerFeedback> JcdCustomerFeedback { get; set; }
    }
}
