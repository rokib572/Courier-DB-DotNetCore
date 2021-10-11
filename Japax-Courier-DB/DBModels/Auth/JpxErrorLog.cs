using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Auth
{
    public partial class JpxErrorLog
    {
        public long ErrId { get; set; }
        public int? ErrLineNo { get; set; }
        public string ErrMessage { get; set; }
        public string ErrInnerException { get; set; }
        public string ErrStackTrace { get; set; }
        public int? ErrNo { get; set; }
        public string ErrProcedure { get; set; }
        public string ErrMethod { get; set; }
        public string ErrMethodPayload { get; set; }
        public string ErrEntity { get; set; }
        public DateTime? ErrRaisedDate { get; set; }
        public byte? ErrStatus { get; set; }
        public long? UserId { get; set; }
    }
}
