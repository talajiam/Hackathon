using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAAS.Entities
{
    public class DellyOrder
    {
        public int ProductId { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int TotalOrder { get; set; }

        public int PendingOrder
        {
            get
            {
                return TotalOrder - CompletedOrder;
            }
        }

        public int CompletedOrder { get; set; }
    }
}