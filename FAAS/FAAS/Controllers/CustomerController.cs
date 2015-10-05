using FAAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAAS.Controllers
{
    public class CustomerController : ApiController
    {

        public static List<Customer> listCustomer = new List<Customer>();
            
        static CustomerController()
        {
            listCustomer.Add(new Customer() {
                CustomerName = "Uday",
                Address = "House No 88 ,Cofely Hatfield",
                ImageUrl = @"/Images/Location/Cofely.jpg",
                EmailId = "up.singh01@gmail.com",
                Postcode = "Al74FG",
                Password = "12345678",
                MobileNo = "9035009999",
                CustomerID = 1001 
            });
            listCustomer.Add(new Customer()
            {
                CustomerName = "Venkat",
                Address = "Cobalt Business Park London",
                EmailId = "venkat@gmail.com",
                Postcode = "Al74FG",
                Password = "12345678",
                MobileNo = "9035009900",
                CustomerID = 1002,
                ImageUrl = @"/Images/Location/Cobalt.jpg"
            });

        }

        // GET api/customer
        public IEnumerable<Customer> Get()
        {
            //if (listCustomer.Count <= 0)
            //{
            //    listCustomer.Add(new Customer() { Address = "#32/788 ITPL Bangalore 560066", CustomerID = 123, CustomerName = "Brijesh", EmailId = "Brijesh.belluru@gmail.com", MobileNo = "09753435667", Password = "Brijesh", Postcode = "560066" });
            //}
            return listCustomer;
        }

        // GET api/customer/5
        public IEnumerable<Customer> Get(int id)
        {
            return listCustomer.FindAll(customer => customer.CustomerID == id);
        }

        // GET api/customer/5
        [HttpGet]
        public IEnumerable<Customer> Login(string emailId)
        {
            //.Replace(" ","")
            return listCustomer.FindAll(customer => customer.EmailId == emailId.Replace(" ", ""));
        }
        // POST api/customer
        public int Post([FromBody]Customer customer)
        {
            var maxOrderId = listCustomer.Count > 0 ? listCustomer.Max(o => o.CustomerID) : 1000;
            customer.CustomerID = maxOrderId + 1;
            if (customer.Address.ToLower().Replace(" ", "").Contains("cobalt"))
            {
                customer.ImageUrl = @"/Images/Location/Cobalt.jpg";
            }
            else if (customer.Address.ToLower().Replace(" ", "").Contains("cofely"))
            {
                customer.ImageUrl = @"/Images/Location/cofely.jpg";
            } else if (customer.Address.ToLower().Replace(" ", "").Contains("accenture"))
            {
                customer.ImageUrl = @"/Images/Location/accenture.jpg";
            }
            else 
            {
                customer.ImageUrl = @"/Images/Location/businesspark.jpg";
            }
            listCustomer.Add(customer);
            return customer.CustomerID;
        }

        // PUT api/customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/customer/5
        public void Delete(int id)
        {
        }
    }
}
