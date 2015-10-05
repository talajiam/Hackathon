using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FAAS.Controllers
{
    public class DeliController : Controller
    {
        //
        // GET: /Delly/

        public ActionResult Index()
        
        {
            List<Entities.DellyOrder> deliOrderList = new List<Entities.DellyOrder>();

            DeliAPIController api = new DeliAPIController();
            deliOrderList = api.Get().ToList();

            //List<Models.ProductItem> Products = new List<Models.ProductItem>();
            //OrderController placeOrder = new OrderController();
            //List<TescoFAAS.Entities.Order> orders = new List<TescoFAAS.Entities.Order>();

            // orders =  placeOrder.Get().ToList();

            ////var groupedCustomerList = orders.GroupBy(u => u.).Select(grp => grp.ToList()).ToList();
            // if (orders.Count > 0)
            // {
            //     foreach (TescoFAAS.Entities.Order order in orders)
            //     {
            //         Products.AddRange(order.Items);
            //     }
            //      var v =   Products.GroupBy(g => g.ProductId).Select(grp => grp.ToList()).ToList();
            //      if (v.Count > 0)
            //      {
            //          foreach(List<Models.ProductItem> uniqPro in v)
            //          { 
            //              Entities.DellyOrder product = new Entities.DellyOrder();
            //              product.ProductId = uniqPro.Count;
            //              if (uniqPro.Count > 0)
            //                  product.TotalOrder = uniqPro.Sum(a => a.Qty);
            //                  product.ImageUrl = uniqPro[0].ImageUrl;
            //                  product.ProductId = uniqPro[0].ProductId;
            //                  product.Name = uniqPro[0].Name;
            //          }                  
            //      }
            // }
            // else
            // {
            //     List<Entities.DellyOrder> order = FAAS.App_Start.Helper.GetDellyOrders().ToList();
            // }


             return View(deliOrderList);
        }

        [HttpPost]
        public ActionResult Index(List<Entities.DellyOrder> orders)
        {
           ;
            DeliAPIController api = new DeliAPIController();
            api.Put(orders.AsEnumerable());

           orders= api.Get().ToList();

            //FAAS.App_Start.Helper.UpdateDellyOrders(orders);
           // List<Entities.DellyOrder> order = FAAS.App_Start.Helper.GetDellyOrders().ToList();
            return View(orders);
        }

      
    }
}
