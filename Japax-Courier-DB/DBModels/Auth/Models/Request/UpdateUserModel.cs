using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Auth.Models.Request
{
    public class UpdateUserModel
    {
        public string UserMobileNo { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string ProfilePicture { get; set; }
    }
}
