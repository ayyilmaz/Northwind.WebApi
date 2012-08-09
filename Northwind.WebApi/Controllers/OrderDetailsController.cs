using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

using Northwind.WebApi.Models;

namespace Northwind.WebApi.Controllers
{
    public class OrderDetailsController : ApiController
    {
        public IEnumerable<OrderDetail> GetOrderDetailsForOrder(int orderId)
        {
            using (var dbContext = new NorthwindDbContext())
            {
                return (from od in dbContext.OrderDetails where od.OrderID == orderId select od).ToList();
            }
        }

        /// <summary>Die Routen für den aktuellen Controller hinzufügen</summary>
        public static void AddRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute(name: "OrderDetailsForOrder",
                                routeTemplate: "orders/{orderId}/orderdetails",
                                defaults: new { controller = "OrderDetails", action = "GetOrderDetailsForOrder" });


        }
    }
}