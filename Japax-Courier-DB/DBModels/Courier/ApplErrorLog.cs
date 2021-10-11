using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class ApplErrorLog
    {
        public string ErrId { get; set; }
        public DateTime? ErrDt { get; set; }
        public string ErrMsgOra { get; set; }
        public string ErrMsgLgcy { get; set; }
        public string ErrRaisedIn { get; set; }
        public string ErrType { get; set; }
        public string ModuleName { get; set; }
    }
}
