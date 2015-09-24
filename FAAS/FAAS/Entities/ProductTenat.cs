using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TescoFAAS.Entities
{
    public class ProductTenat
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TenatId { get; set; }
        public double Price { get; set; }
    }
}