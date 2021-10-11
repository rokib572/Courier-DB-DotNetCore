using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class VwFinsChartOfAccounts
    {
        public int UnitCode { get; set; }
        public int ParentId { get; set; }
        public string ParentAccount { get; set; }
        public int AccId { get; set; }
        public int? ManualId { get; set; }
        public string AccName { get; set; }
        public int? SortOrder { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public byte? SysDefine { get; set; }
        public DateTime EntryDate { get; set; }
        public int EntryUser { get; set; }
        public string EntryBy { get; set; }
        public byte Status { get; set; }
        public string Address { get; set; }
        public string CityDist { get; set; }
        public string PostalCode { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string AddressLocation { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Ext { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string OtherContacts { get; set; }
        public decimal CreditLimit { get; set; }
        public int CreditDays { get; set; }
        public decimal DiscountPercentage { get; set; }
        public int DiscountDays { get; set; }
        public string TermsAndCondition { get; set; }
        public string Notes { get; set; }
        public DateTime? DetEditDate { get; set; }
        public int? DetEditUser { get; set; }
        public string UserName { get; set; }
    }
}
