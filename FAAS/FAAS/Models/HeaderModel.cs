using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAAS.Models
{
    public class HeaderModel
    {
        public string TenantImageUrl { get; set; }

        public List<ProductItem> productItems { get; set; }

        public int CustmorID { get; set; }

        public string CustomerName { get; set; }

        public List<ProductItem> productItemsVal { get; set; }
    }
}