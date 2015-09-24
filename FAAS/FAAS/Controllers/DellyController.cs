using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FAAS.Controllers
{
    public class DellyController : Controller
    {
        //
        // GET: /Delly/

        public ActionResult Index()
        {

            List<Entities.DellyOrder> order = FAAS.App_Start.Helper.GetDellyOrders().ToList();
            return View(order);
        }

        [HttpPost]
        public ActionResult Index(List<Entities.DellyOrder> orders)
        {
            FAAS.App_Start.Helper.UpdateDellyOrders(orders);
            List<Entities.DellyOrder> order = FAAS.App_Start.Helper.GetDellyOrders().ToList();
            return View(order);
        }
    }
}
