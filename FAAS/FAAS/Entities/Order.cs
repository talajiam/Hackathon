using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TescoFAAS.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public string MobileNo { get; set; }
        public int status { get; set; }

        public List<Product> Items { get; set; }

        public Order()
        {
            Items = new List<Product>();
        }
    }
}