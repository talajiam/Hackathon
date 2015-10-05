using FAAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TescoFAAS.Entities;

namespace FAAS.Controllers
{
    public class DeliAPIController : ApiController
    {

        public static List<DellyOrder> listDeliOrders = new List<DellyOrder>();
        // GET api/deliapi
        public IEnumerable<DellyOrder> Get()
        {

            return listDeliOrders;

        }

        // GET api/deliapi/5
        public IEnumerable<DellyOrder> Get(int id)
        {
            return listDeliOrders.FindAll(product => product.ProductId == id);
        }

        // POST api/deliapi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/deliapi/5
        public void Put([FromBody]IEnumerable<DellyOrder> orders)
        {
            orders.ToList().ForEach(order =>
            {
              var productorder= listDeliOrders.FindAll(deliorder => deliorder.ProductId == order.ProductId).FirstOrDefault();
              productorder.CompletedOrder = order.CompletedOrder;

            });
        }

        // DELETE api/deliapi/5
        public void Delete(int id)
        {
        }
    }
}
