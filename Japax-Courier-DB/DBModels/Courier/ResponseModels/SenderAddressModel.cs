using System;
using System.Collections.Generic;
using System.Text;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class SenderAddressModel
    {
        public string Status { get; set; }        
        public AddressModel SenderAddress { get; set; }

        public List<AddressModel> SenderAddressList { get; set; }
        public ErrorModel Error { get; set; }

    }   
}

public class AddressAreaModel
{
    public int AreaId { get; set; }
    public string AreaName { get; set; }
    public int PsUpazillaId { get; set; }
    public string PsUpazillaName { get; set; }
    public byte UnderCityCorporation { get; set; }
    public int DistrictCityId { get; set; }
    public string DistrictCityName { get; set; }
    public int ProvinceId { get; set; }
    public string ProvinceName { get; set; }
    public int CountryId { get; set; }
    public string CountryName { get; set; }
}
public class AddressModel
{
    public long ID { get; set; }
    public long SenderId { get; set; }
    public string AddressType { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public int AreaId { get; set; }
    public string AreaName { get; set; }
    public int PsUpazillaId { get; set; }
    public string PsUpazillaName { get; set; }
    public int DistrictCityId { get; set; }
    public string DistrictCityName { get; set; }
    public int ProvinceId { get; set; }
    public string ProvinceName { get; set; }
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public string HouseOrRoadNo { get; set; }    
    public string PostalCode { get; set; }
    public string LandMark { get; set; }
    public string Street { get; set; }
    public decimal? Lat { get; set; }
    public decimal? Lang { get; set; }
    public DateTime? EntryDate { get; set; }
    public byte? ActiveStatus { get; set; }
    public string FormattedAddress { get; set; }
}
