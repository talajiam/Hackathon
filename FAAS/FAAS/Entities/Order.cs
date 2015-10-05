using FAAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TescoFAAS.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }
        public int TotalItemCount { get; set; }
        public double DeliveryCharge { get; set; }
        public string MobileNo { get; set; }
        public OrderStatus Status { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryLocationCode { get; set; }
        public DateTime DeliveryStartDate { get; set; }
        public DateTime DeliveryEndDate { get; set; }
        public DateTime WebcutoffDateTime { get; set; }
        public List<ProductItem> Items { get; set; }

        public Order()
        {
            Items = new List<ProductItem>();
        }
    }

    public enum OrderStatus
    {
        Confirm=10,
        Cancel=20
    }
}