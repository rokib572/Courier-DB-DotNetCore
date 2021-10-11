using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdMerchantOrStarUserDet
    {
        public long SenderId { get; set; }
        public string ClientMobileNo { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientEmail { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string ClientLogo { get; set; }
        public string FacebookLink { get; set; }
        public string Twiter { get; set; }
        public string OthersLink { get; set; }
        public int? TradeLicenseNo { get; set; }
        public int? Bin { get; set; }
        public int? Nid { get; set; }
        public string DrivingLicenseNo { get; set; }
        public decimal? CreditLimit { get; set; }
        public byte? CreditDays { get; set; }
        public string DefaultPaymentMethod { get; set; }
        public string Remarks { get; set; }

        public virtual JcdSenderInfo Sender { get; set; }
    }
}
