using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdRestaurantInfo
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string HouseOrRoadNo { get; set; }
        public string Street { get; set; }
        public int? PsUpazlaId { get; set; }
        public int? AreaId { get; set; }
        public string PostalCode { get; set; }
        public string Landmarjk { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string MobileNo { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal? CreditLimit { get; set; }
        public byte? CreditDays { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RestaurantImage { get; set; }
        public int UserId { get; set; }
        public DateTime? SetDate { get; set; }

        public virtual AdmnUserInfo User { get; set; }
    }
}
