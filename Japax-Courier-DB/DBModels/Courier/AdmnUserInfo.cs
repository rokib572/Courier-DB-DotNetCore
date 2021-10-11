using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class AdmnUserInfo
    {
        public AdmnUserInfo()
        {
            AdmnDepartmentInfo = new HashSet<AdmnDepartmentInfo>();
            AdmnUserRole = new HashSet<AdmnUserRole>();
            AdmnUserUnitPermission = new HashSet<AdmnUserUnitPermission>();
            JcdAssignRequest = new HashSet<JcdAssignRequest>();
            JcdAtcPickupAndDeliveryPoint = new HashSet<JcdAtcPickupAndDeliveryPoint>();
            JcdAtcPointWiseInventoryAcknowledgeByInNavigation = new HashSet<JcdAtcPointWiseInventory>();
            JcdAtcPointWiseInventoryAcknowledgeByOutNavigation = new HashSet<JcdAtcPointWiseInventory>();
            JcdBannerInfo = new HashSet<JcdBannerInfo>();
            JcdCityDistrict = new HashSet<JcdCityDistrict>();
            JcdCountryInfo = new HashSet<JcdCountryInfo>();
            JcdCustomerComplained = new HashSet<JcdCustomerComplained>();
            JcdDeliveryHeroDocs = new HashSet<JcdDeliveryHeroDocs>();
            JcdDeliveryHeroEdu = new HashSet<JcdDeliveryHeroEdu>();
            JcdDeliveryHeroExp = new HashSet<JcdDeliveryHeroExp>();
            JcdDeliveryHeroInfo = new HashSet<JcdDeliveryHeroInfo>();
            JcdDeliveryTimeSlots = new HashSet<JcdDeliveryTimeSlots>();
            JcdDestinationCharge = new HashSet<JcdDestinationCharge>();
            JcdDiscountOfferInfo = new HashSet<JcdDiscountOfferInfo>();
            JcdInitialDiscountForMerchant = new HashSet<JcdInitialDiscountForMerchant>();
            JcdManifestInfo = new HashSet<JcdManifestInfo>();
            JcdNotificationSmsMaster = new HashSet<JcdNotificationSmsMaster>();
            JcdPickupAndDeliveryArea = new HashSet<JcdPickupAndDeliveryArea>();
            JcdPickupAndDeliveryCharge = new HashSet<JcdPickupAndDeliveryCharge>();
            JcdPsUpazila = new HashSet<JcdPsUpazila>();
            JcdRestaurantInfo = new HashSet<JcdRestaurantInfo>();
        }

        public string UserName { get; set; }
        public int UserId { get; set; }
        public string UserPass { get; set; }
        public string PassHint { get; set; }
        public string Salt { get; set; }
        public byte ActiveStatus { get; set; }
        public DateTime? EntryDate { get; set; }

        public virtual ICollection<AdmnDepartmentInfo> AdmnDepartmentInfo { get; set; }
        public virtual ICollection<AdmnUserRole> AdmnUserRole { get; set; }
        public virtual ICollection<AdmnUserUnitPermission> AdmnUserUnitPermission { get; set; }
        public virtual ICollection<JcdAssignRequest> JcdAssignRequest { get; set; }
        public virtual ICollection<JcdAtcPickupAndDeliveryPoint> JcdAtcPickupAndDeliveryPoint { get; set; }
        public virtual ICollection<JcdAtcPointWiseInventory> JcdAtcPointWiseInventoryAcknowledgeByInNavigation { get; set; }
        public virtual ICollection<JcdAtcPointWiseInventory> JcdAtcPointWiseInventoryAcknowledgeByOutNavigation { get; set; }
        public virtual ICollection<JcdBannerInfo> JcdBannerInfo { get; set; }
        public virtual ICollection<JcdCityDistrict> JcdCityDistrict { get; set; }
        public virtual ICollection<JcdCountryInfo> JcdCountryInfo { get; set; }
        public virtual ICollection<JcdCustomerComplained> JcdCustomerComplained { get; set; }
        public virtual ICollection<JcdDeliveryHeroDocs> JcdDeliveryHeroDocs { get; set; }
        public virtual ICollection<JcdDeliveryHeroEdu> JcdDeliveryHeroEdu { get; set; }
        public virtual ICollection<JcdDeliveryHeroExp> JcdDeliveryHeroExp { get; set; }
        public virtual ICollection<JcdDeliveryHeroInfo> JcdDeliveryHeroInfo { get; set; }
        public virtual ICollection<JcdDeliveryTimeSlots> JcdDeliveryTimeSlots { get; set; }
        public virtual ICollection<JcdDestinationCharge> JcdDestinationCharge { get; set; }
        public virtual ICollection<JcdDiscountOfferInfo> JcdDiscountOfferInfo { get; set; }
        public virtual ICollection<JcdInitialDiscountForMerchant> JcdInitialDiscountForMerchant { get; set; }
        public virtual ICollection<JcdManifestInfo> JcdManifestInfo { get; set; }
        public virtual ICollection<JcdNotificationSmsMaster> JcdNotificationSmsMaster { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryArea> JcdPickupAndDeliveryArea { get; set; }
        public virtual ICollection<JcdPickupAndDeliveryCharge> JcdPickupAndDeliveryCharge { get; set; }
        public virtual ICollection<JcdPsUpazila> JcdPsUpazila { get; set; }
        public virtual ICollection<JcdRestaurantInfo> JcdRestaurantInfo { get; set; }
    }
}
