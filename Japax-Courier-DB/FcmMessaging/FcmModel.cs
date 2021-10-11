using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.FcmMessaging
{
    public class FcmModel
    {
        public List<string> registration_ids { get; set; }
        public Notification notification { get; set; }
        public object data { get; set; }
    }

    public class Notification
    {
        public string text { get; set; }
        public string title { get; set; }
        public string sound { get; set; }
    }
}
