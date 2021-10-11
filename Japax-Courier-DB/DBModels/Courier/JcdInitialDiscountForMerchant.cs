using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdInitialDiscountForMerchant
    {
        public long InitialDiscountId { get; set; }
        public long SenderId { get; set; }
        public int CityDistrictId { get; set; }
        public byte DestinationType { get; set; }
        public byte PickupPoint { get; set; }
        public byte DeliveryPoint { get; set; }
        public byte CalculateBy { get; set; }
        public decimal DiscountAmtOrPer { get; set; }
        public byte? ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdSenderInfo Sender { get; set; }
        public virtual AdmnUserInfo User { get; set; }
    }
}
