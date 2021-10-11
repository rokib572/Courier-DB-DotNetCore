using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class CombinedAddressModel
    {
        public string ExecutionTime { get; set; }
        public CountryInfoModel Countries { get; set; }
        public ProvinceModel Divisions { get; set; }
        public CityDistrictModel Districts { get; set; }
        public UpazillaModel PoliceStations_Upazillas { get; set; }
        public PickupAndDeliveryZoneModel Zones { get; set; }
        public PickupAndDeliveryAreaModel Areas { get; set; }
    }
}
