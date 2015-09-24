using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.UI.DataVisualization.Charting;
using System.Web.Mvc;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Data.Common;
using System.Xml;
//using System.Web.Helpers;
using System.Configuration;
using System.ComponentModel;
using System.Data.Entity;
//using System.Web.UI.DataVisualization;
using FAAS.Models;
using FAAS.Controllers;
using System.IO;

namespace FAAS.Controllers
{
     
    public class HomeController : Controller
    {
        Database1Entities db = new Database1Entities();    
        public ActionResult Index()
        {
            ViewBag.Message = "Food as a Service";
            ViewBag.Message = "Your Products page.";
            var teantid = FAAS.App_Start.Helper.GetTeantId();
            var products = FAAS.App_Start.Helper.GetProducts(teantid);
            FAAS.Models.HeaderModel model = new Models.HeaderModel();
            model.TenantImageUrl = FAAS.App_Start.Helper.GetCustomLogo(teantid);
            model.productItems = products;
            return View(model);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Products()
        {
            ViewBag.Title = "Products";
            ViewBag.Message = "Your Products page.";
            var teantid = FAAS.App_Start.Helper.GetTeantId();
            var products = FAAS.App_Start.Helper.GetProducts(teantid);
            FAAS.Models.HeaderModel model = new Models.HeaderModel();
            model.TenantImageUrl = FAAS.App_Start.Helper.GetCustomLogo(teantid);
            model.productItems = products;
            return View(model);
        }
        [HttpPost]
        public ActionResult Products(FAAS.Models.HeaderModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            int ItemsCount = 0;
            double TotalBill = 0;

            Entities.Checkout chekout = new Entities.Checkout();
            try
            {
                foreach (var prodct in model.productItems)
                {
                    if (prodct.IsSelected || prodct.Qty > 0)
                    {
                        ItemsCount++;
                        TotalBill += prodct.Price * prodct.Qty;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            chekout.ItemQty = ItemsCount;
            chekout.TotalPrice = TotalBill;

            return View("Payment", chekout);

        }
        public ActionResult Payment()
        {
            ViewBag.Message = "Payment";

            return View();
        }
        [HttpPost]
        public ActionResult Payment(FAAS.Models.HeaderModel model)
        {

            int ItemsCount = 0;
            double TotalBill = 0;

            Entities.Checkout chekout = new Entities.Checkout();
            try
            {
                foreach (var prodct in model.productItems)
                {
                    if (prodct.IsSelected)
                    {
                        ItemsCount++;
                        TotalBill += prodct.Price * prodct.Qty;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            chekout.ItemQty = ItemsCount;
            chekout.TotalPrice = TotalBill;

            return View("ConfirmOrder", chekout);

        }
        public ActionResult ConfirmOrder()
        {
            ViewBag.Message = "Order Confirmation";

            return View();
        }
    }
}
