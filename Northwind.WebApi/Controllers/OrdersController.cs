using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Northwind.WebApi.Models;

namespace Northwind.WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        public IEnumerable<Order> Get(string id)
        {
            using (var dbContext = new NorthwindDbContext())
            {
                return (from o in dbContext.Orders where o.CustomerID == id select o).ToList();
            }
        }
    }
}