using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAAS.Entities
{
    public class PickingOrder
    {
        public int OrderId { get; set; }

        public string CustomerAddress { get; set; }
        public string Postcode { get; set; }

        public string DeliveryTime { get; set; }
        public string BarcodeUrl { get; set; }

    }
}