using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAAS.Models
{
    public class HeaderModel
    {
        public string TenantImageUrl { get; set; }

        public List<ProdcutItems> productItems { get; set; }
    }
}