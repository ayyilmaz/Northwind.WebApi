using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Northwind.WebApi.Models;

namespace Northwind.WebApi.Controllers
{
    public class OrderDetailsController : ApiController
    {
        public IEnumerable<OrderDetail> Get(int id)
        {
            using (var dbContext = new NorthwindDbContext())
            {
                return (from od in dbContext.OrderDetails where od.OrderID == id select od).ToList();
            }
        }
    }
}