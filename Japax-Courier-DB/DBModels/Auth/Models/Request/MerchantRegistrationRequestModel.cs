using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Auth.Models.Request
{
    public class MerchantRegistrationRequestModel
    {
        public string RepresentativeMobileNo { get; set; }
        public string RepresentativeFirstName { get; set; }
        public string RepresentativeLastName { get; set; }
        public string RepresentativeEmail { get; set; }
        public string CompanyName { get; set; }
        public string WebsiteAddress { get; set; }
        public string CompanyLogo { get; set; }
        public string FacebookPageLink { get; set; }
        public string TwitterLink { get; set; }
        public string OtherLink { get; set; }
        public int TradeLicenseNo { get; set; }
        public int BinNo { get; set; }
        public int NationalIdNo { get; set; }
        public string DrivingLicenseNo { get; set; }
        public string Remarks { get; set; }
        public string DeviceId { get; set; }
        public byte DeviceType { get; set; }
        public string FcmToken { get; set; }
        public string SecretKey { get; set; }
        public byte SenderType { get; set; }
        public byte CourierApp { get; set; }
        public byte RideshareApp { get; set; }
    }
}
