using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TescoFAAS.Entities;
using FAAS.Models;
using FAAS.Entities;

namespace FAAS.App_Start
{
    public class Helper
    {

        public static IList<DellyOrder> GetDellyOrders()
        {
            return MockData.mockDellyOrder;
        }

        public static void UpdateDellyOrders(List<DellyOrder> updatedOrders)
        {
            foreach (var order in updatedOrders)
            {
                var mockOrd = MockData.mockDellyOrder.Where(e => e.ProductId == order.ProductId).FirstOrDefault();

                mockOrd.CompletedOrder = order.CompletedOrder;
                mockOrd.PendingOrder = mockOrd.PendingOrder - order.CompletedOrder;
            }
        }

        public static List<ProdcutItems> GetProducts(int tenantId)
        {
            List<ProdcutItems> items = new List<ProdcutItems>();

            var tenantProducts = MockData.ProductTenant.Where(e => e.TenatId == tenantId);

            foreach (var product in tenantProducts)
            {
                var prod = MockData.Products.Where(e => e.ProductId == product.ProductId).FirstOrDefault();
                if (prod != null)
                {
                    items.Add(new ProdcutItems() { ProductId = prod.ProductId, Name = prod.Name, ImageUrl = prod.ImageUrl, Calories = prod.Calories, Price = product.Price });
                }
            }

            return items;
        }

        public static int GetDefaultTenantId()
        {
            return 1;
        }

        public static int GetTeantId()
        {
            string[] host = HttpContext.Current.Request.Headers["Host"].Split(':');
            if (host[0].Contains("localhost"))
            {
                return GetDefaultTenantId();
            }
            else if (host[0].Contains("brilliant.tesco.com"))
            {
                return 2;
            }
            else if (host[0].Contains("palatine.tesco.com"))
            {
                return 1;
            }

            return 1;
        }

        public static string GetCustomCss(int tenantId)
        {
            var tenant = MockData.Tenants.Where(e => e.Id == tenantId).FirstOrDefault();

            if (tenant == null)
            {
                tenantId = Helper.GetDefaultTenantId();
                tenant = MockData.Tenants.Where(e => e.Id == tenantId).FirstOrDefault();
                return tenant.CSSUrl;
            }

            return tenant.CSSUrl;
        }

        public static string GetCustomLogo(int tenantId)
        {
            var tenant = MockData.Tenants.Where(e => e.Id == tenantId).FirstOrDefault();

            if (tenant == null)
            {
                tenantId = Helper.GetDefaultTenantId();
                tenant = MockData.Tenants.Where(e => e.Id == tenantId).FirstOrDefault();
                return tenant.LogoUrl;
            }

            return tenant.LogoUrl;
        }
    }
}