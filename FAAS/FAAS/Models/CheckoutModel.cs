using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAAS.Models
{
    public class CheckoutModel
    {

        public int TotalItemQty { get; set; }

        public double TotalPrice { get; set; }

        public List<ProductItem> ProdcutItems { get; set; }

        public int CustmorID { get; set; }

        public string CustomerName { get; set; }
       
        public double DeliveryCharge { get; set; }

        public string MobileNo { get; set; }
        
        public string DeliveryAddress { get; set; }
       
        public string DeliveryLocationCode { get; set; }

        public DateTime DeliveryStartDate { get; set; }
        public DateTime DeliveryEndDate { get; set; }

        public int OrderId { get; set; }



    }
}