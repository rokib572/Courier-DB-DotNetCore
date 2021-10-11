using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.CommonModels.Response;
using Newtonsoft.Json;

namespace Japax_Courier_DB.Cipher
{
    public class CipherPayload
    {
        public string Status { get; set; }
        public string PayLoad { get; set; }       
        public ErrorModel Error { get; set; }
    }
}
