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
        public ActionResult Index(LoginDetails loninDetail)
        {
            if (loninDetail.CustomerEmail == null)
            {
                return RedirectToAction("LogIn");
            }
            CustomerController custReg = new CustomerController();
            List<Customer> customerList = custReg.Get().ToList();



            ViewBag.Message = "Food as a Service";
            ViewBag.Message = "Your Products page.";
            var teantid = FAAS.App_Start.Helper.GetTeantId();
            //ServiceController con = new ServiceController();
            // IEnumerable<string> pro =con.Get();
            ProductController proCon = new ProductController();
            var products = proCon.Get();

            //  var products = FAAS.App_Start.Helper.GetProducts(teantid);
            FAAS.Models.HeaderModel model = new Models.HeaderModel();
            model.TenantImageUrl = FAAS.App_Start.Helper.GetCustomLogo(teantid);

            model.productItems = products.ToList().FindAll(a => a.ProductId == 100);
            if (customerList.Count > 0)
            {
                var customer = customerList.Find(a => a.EmailId == loninDetail.CustomerEmail);
                model.CustmorID = customer.CustomerID;
                Session["userId"] = model.CustmorID;
                Session["CustomerName"] = loninDetail.CustomerName;
                Session["Image"] = customer.ImageUrl;
            }

            return View(model);


        }
        [HttpPost]
        public ActionResult Index(FAAS.Models.HeaderModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int ItemsCount = 0;
            double TotalBill = 0;
            Entities.UserOrder Order = new Entities.UserOrder();
            Entities.Checkout chekout = new Entities.Checkout();
            CheckoutModel chekoutmodel = new CheckoutModel();
            List<ProductItem> proList = new List<ProductItem>();
            try
            {
                foreach (var prodct in model.productItems)
                {
                    if (prodct.IsSelected || prodct.Qty > 0)
                    {
                        ProductItem confirmedProduct = new ProductItem();
                        ItemsCount++;
                        TotalBill += prodct.Price * prodct.Qty;
                        confirmedProduct.ProductId = prodct.ProductId;
                        confirmedProduct.Qty = prodct.Qty;
                        confirmedProduct.Price = prodct.Price;
                        confirmedProduct.Name = prodct.Name;
                        confirmedProduct.Calories = prodct.Calories;
                        confirmedProduct.ImageUrl = prodct.ImageUrl;
                        proList.Add(confirmedProduct);
                    }
                }

                chekoutmodel.TotalPrice = TotalBill;
                chekoutmodel.TotalItemQty = ItemsCount;
                chekoutmodel.ProdcutItems = proList;


                // Get Customer Address Detail Based on CustID



                CustomerController custReg = new CustomerController();
                List<Customer> customerList = custReg.Get(model.CustmorID).ToList(); chekoutmodel.CustmorID = model.CustmorID;
                if (customerList.Count > 0)
                {
                    chekoutmodel.CustomerName = customerList[0].CustomerName; //address.CustomerName;
                    chekoutmodel.DeliveryLocationCode = customerList[0].Postcode; //address.Postcode;
                    chekoutmodel.DeliveryAddress = customerList[0].Address;//address.Address;
                    chekoutmodel.MobileNo = customerList[0].MobileNo.ToString(); //address.MobileNo;

                }
                else
                {
                    Customer address = new Customer();
                    chekoutmodel.CustomerName = "Uday"; //address.CustomerName;
                    chekoutmodel.DeliveryLocationCode = "AL74FG"; //address.Postcode;
                    chekoutmodel.DeliveryAddress = "House No 10 ,Heartford";//address.Address;
                    chekoutmodel.MobileNo = "9739027030"; //address.MobileNo;                
                }
                chekoutmodel.DeliveryCharge = 5;
                chekoutmodel.DeliveryStartDate = DateTime.Today.AddHours(12);
                chekoutmodel.DeliveryEndDate = DateTime.Today.AddHours(13);
            }

            catch (Exception ex)
            {
            }
            chekout.ItemQty = ItemsCount;
            chekout.TotalPrice = TotalBill;

            return View("Payment", chekoutmodel);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Logout()
        {
            ViewBag.Message = "Your app description page.";

            return RedirectToAction("LogIn");
        }

        public ActionResult Register()
        {
            Customer customer = new Customer();

            return View(customer);
        }
        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            CustomerController custReg = new CustomerController();
            if (cust.CustomerID == 0)
            {
                int customerId = custReg.Post(cust);
                cust.CustomerID = customerId;
                return RedirectToAction("LogIn");
            }
            else
            {
                List<Customer> customerList = custReg.Get().ToList();
                customerList = customerList.FindAll(a => a.EmailId == cust.EmailId);
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogIn()
        {
            LoginDetails loginDetail = new LoginDetails();
            Session["CustomerName"] = null;
            return View(loginDetail);
        }
        [HttpPost]
        public ActionResult LogIn(LoginDetails loninDetail)
        {
            CustomerController custReg = new CustomerController();
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                List<Customer> customerList = custReg.Get().ToList();
                customerList = customerList.FindAll(a => a.EmailId == loninDetail.CustomerEmail && a.Password == loninDetail.Password1);
                if (customerList.Count > 0)
                {
                    loninDetail.CustomerID = customerList[0].CustomerID;
                    loninDetail.CustomerEmail = customerList[0].EmailId;
                    loninDetail.CustomerName = customerList[0].CustomerName;
                }
                else
                {

                    loninDetail.Password1 = "";
                    loninDetail.CustomerEmail = "";
                    loninDetail.CustomerName = "";
                    return View(loninDetail);
                }
                return RedirectToAction("Index", loninDetail);
            }
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Products(List<ProductItem> productItemVal)
        {
            if (TempData["myObject"] != null)
            {
                productItemVal = (List<ProductItem>)TempData["myObject"];
            }

            if (Session["userId"] == null)
            {
                return RedirectToAction("LogIn");
            }

            ViewBag.Title = "Products";
            ViewBag.Message = "Your Products page.";
            var teantid = FAAS.App_Start.Helper.GetTeantId();
            // var products = FAAS.App_Start.Helper.GetProducts(teantid);
            ProductController proCon = new ProductController();
            var products = proCon.Get();
            if (productItemVal != null)
            {
                products.Where(x => x.ProductId == productItemVal.First().ProductId).ToList().ForEach(a => a.Qty = productItemVal.First().Qty);

            }
            //  products.ToList().FindAll.ForEach(a => a.Qty == productItemVal.First().Qty);

            FAAS.Models.HeaderModel model = new Models.HeaderModel();
            model.TenantImageUrl = FAAS.App_Start.Helper.GetCustomLogo(teantid);
            model.productItems = products.ToList();
            if (Session["userId"] != null)
            {
                var uid = Session["userId"];
                model.CustmorID = (int)uid;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Products(FAAS.Models.HeaderModel model)
        {
            if (model.productItems.Count == 1)
            {
                model.productItemsVal = model.productItems;
                TempData["myObject"] = model.productItems;
                return RedirectToAction("Products", model.productItemsVal);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (Session["userId"] == null)
            {
                return RedirectToAction("LogIn");
            }
            int ItemsCount = 0;
            double TotalBill = 0;
            Entities.UserOrder Order = new Entities.UserOrder();
            Entities.Checkout chekout = new Entities.Checkout();
            CheckoutModel chekoutmodel = new CheckoutModel();
            List<ProductItem> proList = new List<ProductItem>();
            try
            {
                foreach (var prodct in model.productItems)
                {
                    if (prodct.IsSelected || prodct.Qty > 0)
                    {
                        ProductItem confirmedProduct = new ProductItem();
                        ItemsCount++;
                        TotalBill += prodct.Price * prodct.Qty;
                        confirmedProduct.ProductId = prodct.ProductId;
                        confirmedProduct.Qty = prodct.Qty;
                        confirmedProduct.Price = prodct.Price;
                        confirmedProduct.Name = prodct.Name;
                        confirmedProduct.Calories = prodct.Calories;
                        confirmedProduct.ImageUrl = prodct.ImageUrl;
                        proList.Add(confirmedProduct);
                    }
                }

                chekoutmodel.TotalPrice = TotalBill;
                chekoutmodel.TotalItemQty = ItemsCount;
                chekoutmodel.ProdcutItems = proList;


                // Get Customer Address Detail Based on CustID
                chekoutmodel.CustmorID = model.CustmorID;
                CustomerController custReg = new CustomerController();
                List<Customer> customerList = custReg.Get(model.CustmorID).ToList();

                if (customerList.Count > 0)
                {
                    Customer address = new Customer();
                    chekoutmodel.CustomerName = customerList[0].CustomerName; //address.CustomerName;
                    chekoutmodel.DeliveryLocationCode = customerList[0].Postcode; //address.Postcode;
                    chekoutmodel.DeliveryAddress = customerList[0].Address;//"House No 10 ,Heartford" ;//address.Address;
                    chekoutmodel.MobileNo = customerList[0].MobileNo.ToString(); //"9739027030"; //address.MobileNo;
                }
                else
                {
                    Customer address = new Customer();
                    chekoutmodel.CustomerName = "Uday"; //address.CustomerName;
                    chekoutmodel.DeliveryLocationCode = "AL74FG"; //address.Postcode;
                    chekoutmodel.DeliveryAddress = "House No 10 ,Heartford";//address.Address;
                    chekoutmodel.MobileNo = "9739027030"; //address.MobileNo;
                }

                chekoutmodel.DeliveryCharge = 0;

                chekoutmodel.DeliveryStartDate = DateTime.Today.AddHours(12);
                chekoutmodel.DeliveryEndDate = DateTime.Today.AddHours(13);
            }

            catch (Exception ex)
            {
            }
            chekout.ItemQty = ItemsCount;
            chekout.TotalPrice = TotalBill;

            return View("Payment", chekoutmodel);

        }
        public ActionResult Payment()
        {
            ViewBag.Message = "Payment";

            return View();
        }
        [HttpPost]
        public ActionResult Payment(FAAS.Models.CheckoutModel model)
        {

            int ItemsCount = 0;
            double TotalBill = 0;

            Entities.Checkout chekout = new Entities.Checkout();

            chekout.CustmorID = 1;
            try
            {

                //Make Confirm Call

                OrderController placeOrder = new OrderController();
                TescoFAAS.Entities.Order order = new TescoFAAS.Entities.Order();

                order.CustomerId = model.CustmorID;
                order.CustomerName = model.CustomerName;
                order.DeliveryAddress = model.DeliveryAddress;
                order.DeliveryCharge = model.DeliveryCharge;
                order.DeliveryLocationCode = model.DeliveryLocationCode;
                order.DeliveryStartDate = model.DeliveryStartDate;
                order.DeliveryEndDate = model.DeliveryEndDate;
                //order.Id = RandomNumber(50000,60000);
                order.Items = model.ProdcutItems;
                order.MobileNo = model.MobileNo;
                order.TotalItemCount = model.TotalItemQty;
                order.TotalPrice = model.TotalPrice;
                order.Status = TescoFAAS.Entities.OrderStatus.Confirm;
                order.WebcutoffDateTime = DateTime.Today.AddHours(8);

                int orderID = placeOrder.Post(order);
                model.OrderId = orderID;
                chekout.OrderId = orderID;
                //foreach (var prodct in model.productItems)
                //{
                //    if (prodct.IsSelected)
                //    {
                //        ItemsCount++;
                //        TotalBill += prodct.Price * prodct.Qty;
                //    }
                //}
            }
            catch (Exception ex)
            {

            }

            chekout.ItemQty = ItemsCount;
            chekout.TotalPrice = TotalBill;

            return View("ConfirmOrder", model);

        }

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public ActionResult ConfirmOrder()
        {
            ViewBag.Message = "Order Confirmation";

            return View();
        }
    }
}
