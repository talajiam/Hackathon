using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TescoFAAS.Entities;

namespace FAAS.Models
{
    public class ProdcutItems
    {
        public bool IsSelected { get; set; }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int Calories { get; set; }

        public int Qty { get; set; }
    }
}