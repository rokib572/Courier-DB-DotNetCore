using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class SenderDetailsResponseModel
    {
        public long SenderId { get; set; }
        public string UserMobileNo { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public byte AllowableAddress { get; set; }
        public byte RewardPoint { get; set; }
        public string FCMToken { get; set; }
        public string ProfilePicture { get; set; }
        public string DeviceId { get; set; }
        public byte DeviceType { get; set; }
        public string SecretKey { get; set; }
        public DateTime RegistrationDate { get; set; }
        public byte CourierApp { get; set; }
        public byte RideshareApp { get; set; }
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
        public decimal CreditLimit { get; set; }
        public byte CreditDays { get; set; }
        public string DefaultPaymentMethod { get; set; }
        public string Remarks { get; set; }
    }
    public class SenderDetailsRespModel 
    {
        public string Status { get; set; }
        public List<SenderDetailsResponseModel> SenderDetails { get; set; }
        public ErrorModel Error { get; set; }
    }
}
