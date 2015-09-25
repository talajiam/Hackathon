using FAAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAAS.Controllers
{
    public class ServiceController : ApiController
    {

       List<UserOrder> orderList = new List<UserOrder>();
        // GET api/fass
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/fass/5
        public IEnumerable<UserOrder> Get(int id)
        {
            UserOrder order = orderList.Find(a=>a.OrderID ==id.ToString());
            //return "value";
            return orderList;
        }

        // POST api/fass
        public void Post([FromBody]string value)
        {
        }

        // PUT api/fass/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/fass/5
        public void Delete(int id)
        {
        }
    }
}
