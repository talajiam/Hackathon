﻿using FAAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAAS.Entities
{
    public class Checkout
    {
        public int ItemQty { get; set; }

        public double TotalPrice { get; set; }
        
        public List<ProductItem> ProdcutItems { get; set; }

        public int CustmorID { get; set; }

         public int OrderId { get; set; }
    }
}