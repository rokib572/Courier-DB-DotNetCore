using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdCustomerComplained
    {
        public long RequestId { get; set; }
        public byte ComplainedBy { get; set; }
        public byte ComplainedAgainst { get; set; }
        public string ComplainedDet { get; set; }
        public string WhatStepTaken { get; set; }
        public int? StepTakenBy { get; set; }
        public byte? ComplainedStatus { get; set; }

        public virtual JcdPickupAndDeliveryRequest Request { get; set; }
        public virtual AdmnUserInfo StepTakenByNavigation { get; set; }
    }
}
