using FAAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAAS.Entities
{
    public class UserOrder
    {
        public List<Product> product { get; set; }

        public string OrderID {get; set;}

        public double TotalPrice { get; set; }

        public string LocationCode { get; set; }

        public String Address { get; set; }
    }
}