using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TescoFAAS.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }

        public int Calories { get; set; }
    }
}