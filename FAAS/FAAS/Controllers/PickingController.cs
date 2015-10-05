using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FAAS.Controllers
{
    public class PickingController : Controller
    {
        //
        // GET: /Picking/

        public ActionResult Index()
        {
            List<Entities.PickingOrder> pickingOrder=new List<Entities.PickingOrder>();
            OrderController ord = new OrderController();

            var orders = ord.Get().ToList();
            orders.ForEach(order=>
                {
                    pickingOrder.Add(new Entities.PickingOrder() { OrderId = order.Id, BarcodeUrl = "/Images/barcode/2.jpg", CustomerAddress = order.DeliveryAddress, DeliveryTime = order.DeliveryStartDate.ToString(), Postcode = order.DeliveryLocationCode });

                });
            //List<Entities.PickingOrder> order = FAAS.App_Start.Helper.GetPickingOrders().ToList();
            return View(pickingOrder);
        }

        [HttpPost]
        public ActionResult Index(List<Entities.PickingOrder> orders)
        {
            FAAS.App_Start.Helper.UpdatePickingOrder(orders);
            List<Entities.PickingOrder> order = FAAS.App_Start.Helper.GetPickingOrders().ToList();
            return View(order);
        }

    }
}
