using Japax_Courier_DB.DBModels.CommonModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Japax_Courier_DB.DBModels.Courier.ResponseModels
{
    public class DeliverySlotsModel
    {
        public string Status { get; set; }
        public List<DeliverySlotsInfo> DeliverySlots { get; set; }
        public DeliverySlotsInfo DeliverySlot { get; set; }
        public ErrorModel Error { get; set; }
    }

    public class DeliverySlotsInfo
    {
        public int DeliverySlotsId { get; set; }
        public string DeliveryType { get; set; }
        public string Disclaimer { get; set; }
    }
}
