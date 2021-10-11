using System;
using System.Collections.Generic;

namespace Japax_Courier_DB.DBModels.Courier
{
    public partial class JcdSenderAddress
    {
        public long Id { get; set; }
        public long SenderId { get; set; }
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string HouseOrRoadNo { get; set; }
        public string Street { get; set; }
        public int AreaId { get; set; }
        public string PostalCode { get; set; }
        public string Landmark { get; set; }
        public decimal? LatitudesData { get; set; }
        public decimal? LongitudesData { get; set; }
        public byte? GeolocationStatus { get; set; }
        public byte? ActiveStatus { get; set; }
        public DateTime? EntryDate { get; set; }
        public string EnteredBy { get; set; }

        public virtual JcdPickupAndDeliveryArea Area { get; set; }
        public virtual JcdSenderInfo Sender { get; set; }
    }
}
