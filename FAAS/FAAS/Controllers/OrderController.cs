using FAAS.Helper;
using FAAS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TescoFAAS.Entities;

namespace FAAS.Controllers
{

    public class OrderController : ApiController
    {
        public static List<Order> listOrders = new List<Order>();

        //string orderfilePath = Path.Combine(new string[] { Helper.Helper.CSVFilePath, "Orders.csv" });
        // GET api/order
        public IEnumerable<Order> Get()
        {
            //List<Order> orderList = new List<Order>();

            //int rowid = 0;
            //// Read sample data from CSV file
            //using (CsvFileReader reader = new CsvFileReader(orderfilePath))
            //{
            //    CsvRow row = new CsvRow();
            //    while (reader.ReadRow(row))
            //    {
            //        if (rowid > 0)
            //        { 
            //            orderList.Add(new Order()
            //            {
            //                Id = Convert.ToInt32(row[0]),
            //                CustomerId = Convert.ToInt32(row[1]),
            //                CustomerName = row[2],
            //                TotalPrice = Convert.ToDouble(row[3]),
            //                TotalItemCount = Convert.ToInt32(row[4]),
            //                DeliveryCharge = Convert.ToDouble(row[5]),
            //                MobileNo = row[6],
            //                Status = OrderStatus.Confirm,
            //                DeliveryAddress = row[8],
            //                DeliveryLocationCode = row[9],
            //                DeliveryStartDate=Convert.ToDateTime( row[10]),
            //                DeliveryEndDate=Convert.ToDateTime( row[11]),
            //                WebcutoffDateTime=Convert.ToDateTime( row[12])
            //            });
            //        }
            //        rowid++;
            //    }
            //}
            //if (listOrders.Count > 0)
            //{
            //    listOrders[0].Items = new List<ProductItem>();
            //    listOrders[0].Items.Add(new ProductItem() { ProductId = 123, Name = "test", Calories = 10, ImageUrl = "test", Price = 10.9, Qty = 2 });
            //    listOrders[0].Items.Add(new ProductItem() { ProductId = 456, Name = "test", Calories = 10, ImageUrl = "test", Price = 10.9, Qty = 2 });
            //}

            listOrders.ForEach(order =>
                {
                    order.DeliveryStartDate = DateTime.Today.AddHours(12);
                    if (order.DeliveryAddress.ToLower().Contains("bangalore"))
                    {
                        order.DeliveryAddress = "House No 88 ,Cofely Hatfield";
                        order.DeliveryLocationCode = "AL74FG";
                    }

                    
                });
            return listOrders;
        }

        // GET api/order/5
        public IEnumerable<Order> Get(int id)
        {
            //List<Order> orderList = new List<Order>();

            //int rowid = 0;
            //// Read sample data from CSV file
            //using (CsvFileReader reader = new CsvFileReader(orderfilePath))
            //{
            //    CsvRow row = new CsvRow();
            //    while (reader.ReadRow(row))
            //    {
            //        if (rowid > 0)
            //        {
            //            orderList.Add(new Order()
            //            {
            //                Id = Convert.ToInt32(row[0]),
            //                CustomerId = Convert.ToInt32(row[1]),
            //                CustomerName = row[2],
            //                TotalPrice = Convert.ToDouble(row[3]),
            //                TotalItemCount = Convert.ToInt32(row[4]),
            //                DeliveryCharge = Convert.ToDouble(row[5]),
            //                MobileNo = row[6],
            //                Status = OrderStatus.Confirm,
            //                DeliveryAddress = row[8],
            //                DeliveryLocationCode = row[9],
            //                DeliveryStartDate=Convert.ToDateTime( row[10]),
            //                DeliveryEndDate=Convert.ToDateTime( row[11]),
            //                WebcutoffDateTime=Convert.ToDateTime( row[12])
            //            });
            //        }
            //        rowid++;
            //    }
            //}
            return listOrders.FindAll(order => order.Id == id);
        }
        [HttpGet]
        public Order GetByCustomerId(int customerId)
        {
            //List<Order> orderList = new List<Order>();

            //int rowid = 0;
            //// Read sample data from CSV file
            //using (CsvFileReader reader = new CsvFileReader(orderfilePath))
            //{
            //    CsvRow row = new CsvRow();
            //    while (reader.ReadRow(row))
            //    {
            //        if (rowid > 0)
            //        {
            //            orderList.Add(new Order()
            //            {
            //                Id = Convert.ToInt32(row[0]),
            //                CustomerId = Convert.ToInt32(row[1]),
            //                CustomerName = row[2],
            //                TotalPrice = Convert.ToDouble(row[3]),
            //                TotalItemCount = Convert.ToInt32(row[4]),
            //                DeliveryCharge = Convert.ToDouble(row[5]),
            //                MobileNo = row[6],
            //                Status = OrderStatus.Confirm,
            //                DeliveryAddress = row[8],
            //                DeliveryLocationCode = row[9],
            //                DeliveryStartDate=Convert.ToDateTime( row[10]),
            //                DeliveryEndDate=Convert.ToDateTime( row[11]),
            //                WebcutoffDateTime=Convert.ToDateTime( row[12])
            //            });
            //        }
            //        rowid++;
            //    }
            //}
            return listOrders.FindAll(order => order.CustomerId == customerId).FirstOrDefault();
        }

        // POST api/order
        [HttpPost]
        public int Post([FromBody]Order order)
        {

            //StringBuilder newOrder = new StringBuilder();
            //newOrder.Append(order.Id);
            //newOrder.AppendFormat(",{0}",order.CustomerId.ToString());
            //newOrder.AppendFormat(",{0}", order.CustomerName);
            //newOrder.AppendFormat(",{0}", order.TotalPrice.ToString());
            //newOrder.AppendFormat(",{0}", order.TotalItemCount.ToString());
            //newOrder.AppendFormat(",{0}", order.DeliveryCharge.ToString());
            //newOrder.AppendFormat(",{0}", order.MobileNo);
            //newOrder.AppendFormat(",{0}", order.Status.ToString());
            //newOrder.AppendFormat(",{0}", order.DeliveryAddress);
            //newOrder.AppendFormat(",{0}", order.DeliveryLocationCode);
            //newOrder.AppendFormat(",{0}", order.DeliveryStartDate);
            //newOrder.AppendFormat(",{0}", order.DeliveryEndDate);
            //newOrder.AppendFormat(",{0}", order.WebcutoffDateTime);
            //List<string> lines = File.ReadAllLines(orderfilePath).ToList();
            //lines.Add(newOrder.ToString());
            //File.WriteAllLines(orderfilePath, lines.ToArray());

            var maxOrderId = listOrders.Count > 0 ? listOrders.Max(o => o.Id) : 10000;
            order.Id = maxOrderId + 1;
            listOrders.Add(order);
            order.Items.ForEach(item =>
                {
                    bool isitemexists = false;
                    DeliAPIController.listDeliOrders.ForEach(deliorder =>
                        {
                            if (deliorder.ProductId == item.ProductId)
                            {
                                isitemexists = true;
                                deliorder.TotalOrder = deliorder.TotalOrder + item.Qty;
                            }
                        });
                    if (!isitemexists)
                    {
                        DeliAPIController.listDeliOrders.Add(new Entities.DellyOrder()
                        { 
                            ProductId = item.ProductId, CompletedOrder = 0, ImageUrl = item.ImageUrl, 
                            Name = item.Name,  TotalOrder = item.Qty
                        });
                    }
                });
            return order.Id;

        }

        // PUT api/order/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/order/5
        public void Delete(int id)
        {
        }
    }
}
