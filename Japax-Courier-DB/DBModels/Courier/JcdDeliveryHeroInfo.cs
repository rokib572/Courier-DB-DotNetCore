using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdDeliveryHeroInfo
    {
        public JcdDeliveryHeroInfo()
        {
            JcdDeliveryHeroDocs = new HashSet<JcdDeliveryHeroDocs>();
            JcdDeliveryHeroEdu = new HashSet<JcdDeliveryHeroEdu>();
            JcdDeliveryHeroExp = new HashSet<JcdDeliveryHeroExp>();
            JcdDhLocationStatus = new HashSet<JcdDhLocationStatus>();
        }

        public long DhId { get; set; }
        public string DhCode { get; set; }
        public string DhFirstName { get; set; }
        public string DhMiddleName { get; set; }
        public string DhLastName { get; set; }
        public string DhMobNo { get; set; }
        public string DhPassword { get; set; }
        public byte DhType { get; set; }
        public byte AssignTeam { get; set; }
        public byte DefaultAssignRole { get; set; }
        public string TransportType { get; set; }
        public string TransportDescription { get; set; }
        public string LicencePlate { get; set; }
        public string TransportColor { get; set; }
        public byte DhStatus { get; set; }
        public decimal? LatitudesData { get; set; }
        public decimal? LongitudesData { get; set; }
        public string DhNationality { get; set; }
        public string DhNid { get; set; }
        public string DhEmailAddr { get; set; }
        public string PermenantAddress { get; set; }
        public string HouseNoPmt { get; set; }
        public string StreetPmt { get; set; }
        public int PsUpazlaIdPmt { get; set; }
        public int AreaIdPmt { get; set; }
        public string PostalCodePmt { get; set; }
        public string LocationPmt { get; set; }
        public string PresentAddress { get; set; }
        public string HouseNoPr { get; set; }
        public string StreetPr { get; set; }
        public int PsUpazlaIdPr { get; set; }
        public int AreaIdPr { get; set; }
        public string PostalCodePr { get; set; }
        public string LocationPr { get; set; }
        public string EmergencyMobNo { get; set; }
        public DateTime JoiningDate { get; set; }
        public string DhImage { get; set; }
        public string FcmToken { get; set; }
        public string DeviceId { get; set; }
        public byte? ActiveStatus { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual JcdPickupAndDeliveryArea AreaIdPmtNavigation { get; set; }
        public virtual JcdPickupAndDeliveryArea AreaIdPrNavigation { get; set; }
        public virtual JcdPsUpazila PsUpazlaIdPmtNavigation { get; set; }
        public virtual JcdPsUpazila PsUpazlaIdPrNavigation { get; set; }
        public virtual AdmnUserInfo User { get; set; }
        public virtual ICollection<JcdDeliveryHeroDocs> JcdDeliveryHeroDocs { get; set; }
        public virtual ICollection<JcdDeliveryHeroEdu> JcdDeliveryHeroEdu { get; set; }
        public virtual ICollection<JcdDeliveryHeroExp> JcdDeliveryHeroExp { get; set; }
        public virtual ICollection<JcdDhLocationStatus> JcdDhLocationStatus { get; set; }
    }
}
