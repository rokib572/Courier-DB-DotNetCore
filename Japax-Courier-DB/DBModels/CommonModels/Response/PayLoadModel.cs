using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Japax_Courier_DB.DBModels.CommonModels.Response
{
    public class PayLoadModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public string SenderID { get; set; }
        public string ExecutionTime { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string PayLoad { get; set; }
    }
}
