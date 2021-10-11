using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdSenderInfo
    {
        public JcdSenderInfo()
        {
            JcdDiscountOfferInfo = new HashSet<JcdDiscountOfferInfo>();
            JcdInitialDiscountForMerchant = new HashSet<JcdInitialDiscountForMerchant>();
            JcdMerchantOrStarUserTran = new HashSet<JcdMerchantOrStarUserTran>();
            JcdPickupAndDeliveryRequest = new HashSet<JcdPickupAndDeliveryRequest>();
            JcdSenderAddress = new HashSet<JcdSenderAddress>();
        }

        public long SenderId { get; set; }
        public byte AllowableAddress { get; set; }
        public byte RewardPoint { get; set; }
        public byte? SenderType { get; set; }
        public byte? ActiveStatus { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdMerchantOrStarUserDet JcdMerchantOrStarUserDet { get; set; }
        public virtual ICollection<JcdDiscountOfferInfo> JcdDiscountOfferInfo { get; set; }
        public virtual ICollection<JcdInitialDiscountForMerchant> JcdInitialDiscountForMerchant { get; set; }
        public virtual ICollection<JcdMerchantOrStarUserTran> JcdMerchantOrStarUserTran { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryRequest> JcdPickupAndDeliveryRequest { get; set; }
        public virtual ICollection<JcdSenderAddress> JcdSenderAddress { get; set; }
    }
}
