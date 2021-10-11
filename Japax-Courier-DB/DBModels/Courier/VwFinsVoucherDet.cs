using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class VwFinsVoucherDet
    {
        public int CompanyCode { get; set; }
        public int FiscalId { get; set; }
        public string FiscalYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UnitCode { get; set; }
        public string UnitName { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptShortName { get; set; }
        public byte VrType { get; set; }
        public DateTime TranDate { get; set; }
        public long SysVrno { get; set; }
        public string UserVrno { get; set; }
        public int SlNo { get; set; }
        public int ParentId { get; set; }
        public string ParentAccount { get; set; }
        public int LedgerId { get; set; }
        public int? ManualId { get; set; }
        public string LedgerName { get; set; }
        public string Particulars { get; set; }
        public decimal DrLocal { get; set; }
        public decimal DrFc { get; set; }
        public decimal CrLocal { get; set; }
        public decimal CrFc { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public byte? InstrumentType { get; set; }
        public string InstrumentNo { get; set; }
        public DateTime? InstrumentDate { get; set; }
        public decimal? ChqAmountLocal { get; set; }
        public decimal? ChqAmountFc { get; set; }
        public string AccountName { get; set; }
        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public byte? InstrumentStatus { get; set; }
        public int? DishonoredStatus { get; set; }
        public string NameInInstrument { get; set; }
        public byte VrStatus { get; set; }
        public int EntryUser { get; set; }
        public string UserName { get; set; }
        public DateTime EntryDate { get; set; }
        public int EditUser { get; set; }
        public string EditUserName { get; set; }
        public DateTime? EditDate { get; set; }
        public int ApproveBy { get; set; }
        public string ApproveUserName { get; set; }
        public DateTime? ApproveDate { get; set; }
        public string Address { get; set; }
        public string CityDist { get; set; }
        public string PostalCode { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
    }
}
