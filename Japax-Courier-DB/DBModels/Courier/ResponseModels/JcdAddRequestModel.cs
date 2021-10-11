using System;
using System.Collections.Generic;
using System.Text;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class JcdAddRequestModel
    {
        public string Status { get; set; }
        public long RequestId { get; set; }
        public long SenderId { get; set; }
        public byte RequestTypeId { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? PickupBefore { get; set; }
        public DateTime? DeliveryBefore { get; set; }
        public int PickupAreaId { get; set; }
        public string PicukupAddressLine1 { get; set; }
        public string PicukupAddressLine2 { get; set; }
        public string PicukupHouseOrRoadNo { get; set; }
        public string PicukupStreet { get; set; }
        public string PicukupPostalCode { get; set; }
        public string PicukupLandmark { get; set; }
        public string ReceiverMobileNo { get; set; }
        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public int ReceiverAreaId { get; set; }
        public string ReceiverAddressLine1 { get; set; }
        public string ReceiverAddressLine2 { get; set; }
        public string ReceiverHouseOrRoadNo { get; set; }
        public string ReceiverStreet { get; set; }
        public string ReceiverPostalCode { get; set; }
        public string ReceiverLandmark { get; set; }
        public byte? ChargeAmountPayby { get; set; }
        public decimal ChargeAmount { get; set; }
        public ErrorModel Error { get; set; }
    }
}
