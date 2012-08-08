using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Northwind.WebApi.Models;

namespace Northwind.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        public IEnumerable<Product> Get()
        {
            try
            {
                using (var dbContext = new NorthwindDbContext())
                {
                    return dbContext.Products.ToList();
                }
            }
            catch (Exception exception)
            {
                new LogEvent(exception.Message).Raise();
            }

            return new List<Product>();
        }

        public Product Get(int id)
        {
            using (var dbContext = new NorthwindDbContext())
            {
                return (from p in dbContext.Products where p.ProductID == id select p).FirstOrDefault();
            }
        }
    }
}