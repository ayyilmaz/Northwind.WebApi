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
            using (var dbContext = new NorthwindDbContext())
            {
                return dbContext.Products.ToList();
            }
        }
    }
}