using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Auth.Models.Response
{
    public class JpxUserLoginInfoModel
    {
        public string Status { get; set; }
        public JpxUserLoginInfo UserInfo { get; set; }
        public List<JpxUserLoginInfo> UserInfoList { get; set; }
        public UserAuthModel UserAuthModel { get; set; }
        public ErrorModel Error { get; set; }
    }
}
