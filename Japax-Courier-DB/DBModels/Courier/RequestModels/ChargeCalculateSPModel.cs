using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.RequestModels
{
    public class ChargeCalculateSPModel
    {
        public int SlNo { get; set; }
        public string ProductTypeId { get; set; }
        public int PackageChargeId { get; set; }
        public decimal PackageWidth { get; set; }
        public decimal PackageHeight { get; set; }
        public decimal PackageLength { get; set; }
        public string DimensionUnit { get; set; }
        public decimal PackageWeight { get; set; }
        public string WeightUnit { get; set; }
        public string ExtraPackagingId { get; set; }
        public string GiftWrappingId { get; set; }
        public int DestinationType { get; set; }
    }
}
