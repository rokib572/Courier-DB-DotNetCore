using Japax_Courier_DB.DBModels.CommonModels.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class DeliveryHeroInfoResponseModel
    {
        public string Status { get; set; }
        public List<DeliveryHeroInfo> DeliveryHeroInfo { get; set; }
        public DeliveryHero DeliveryHero { get; set; }
        public Pagination Pagination { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class Pagination
    {
        public double TotalPage { get; set; }
        public double CurrentPage { get; set; }
        public bool HasNextPage { get; set; }
    }
    public class DeliveryHero
    {
        public long DhId { get; set; }
        public string DhCode { get; set; }
        public string DhFirstName { get; set; }
        public string DhMiddleName { get; set; }
        public string DhLastName { get; set; }
        public string DhMobNo { get; set; }
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
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
    public class DeliveryHeroInfo
    {
        public long DhId { get; set; }
        public string DhCode { get; set; }
        public string DhFirstName { get; set; }
        public string DhMiddleName { get; set; }
        public string DhLastName { get; set; }
        public string DhMobNo { get; set; }
        public string TransportType { get; set; }
        public string EmergencyMobNo { get; set; }
        public DateTime JoiningDate { get; set; }
        public string DhImage { get; set; }
        public byte? ActiveStatus { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
