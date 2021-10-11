using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Auth.Models.Request
{
    public class MerchantUpdateRequestModel
    {
        public long SenderId { get; set; }
        public string RepresentativeFirstName { get; set; }
        public string RepresentativeLastName { get; set; }
        public string RepresentativeEmail { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string FacebookPageLink { get; set; }
        public string TwitterLink { get; set; }
        public string OtherLink { get; set; }
        public decimal CreditLimit { get; set; }
        public byte CreditLimitDays { get; set; }
        public string DefaultPaymentMethod { get; set; }
        public string Remarks { get; set; }
    }
}
