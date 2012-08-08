using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Northwind.WebApi.Models;

namespace Northwind.WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        public IEnumerable<Order> Get()
        {
            using (var dbContext = new NorthwindDbContext())
            {
                var list =  dbContext.Orders.ToList();

                return list;
            }
        }
    }
}