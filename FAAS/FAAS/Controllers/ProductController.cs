using FAAS.Helper;
using FAAS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TescoFAAS.Entities;

namespace FAAS.Controllers
{
    public class ProductController : ApiController
    {

        string productfilePath = Path.Combine(new string[] { Helper.Helper.CSVFilePath, "Products.csv" });
        // GET api/product
        public IEnumerable<ProductItem> Get()
        {
            List<ProductItem> productList = new List<ProductItem>();

            int rowid = 0;
            // Read sample data from CSV file
            using (CsvFileReader reader = new CsvFileReader(productfilePath))
            {
                
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    if (rowid > 0)
                    {
                        productList.Add(new ProductItem() { ProductId = Convert.ToInt32(row[0]), Name = row[1], ImageUrl = row[2], Price = Convert.ToDouble(row[3]), Calories = Convert.ToInt32(row[4]) });
                    }
                    rowid++;
                }
            }
            return productList;
        }

        // GET api/product/5
        public IEnumerable<ProductItem> Get(int id)
        {
            List<ProductItem> productList = new List<ProductItem>();

            int rowid = 0;
            // Read sample data from CSV file
            using (CsvFileReader reader = new CsvFileReader(productfilePath))
            {
                CsvRow row = new CsvRow();
                
                while (reader.ReadRow(row))
                {
                    if (rowid > 0)
                    {
                        productList.Add(new ProductItem() { ProductId = Convert.ToInt32(row[0]), Name = row[1], ImageUrl = row[2], Price = Convert.ToDouble(row[3]), Calories = Convert.ToInt32(row[4]) });
                    }
                    rowid++;
                }
            }
            return productList.FindAll(product=>product.ProductId==id);
        }

        // POST api/product
        public void Post([FromBody]string value)
        {
        }

        // PUT api/product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/product/5
        public void Delete(int id)
        {
        }
    }
}
