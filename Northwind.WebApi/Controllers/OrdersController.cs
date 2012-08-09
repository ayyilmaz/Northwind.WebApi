using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

using Northwind.WebApi.Models;

namespace Northwind.WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        public IEnumerable<Order> Get()
        {
            using (var dbContext = new NorthwindDbContext())
            {
                return (from o in dbContext.Orders select o).ToList();
            }
        }        
        
        public IEnumerable<Order> Get(int id)
        {
            using (var dbContext = new NorthwindDbContext())
            {
                return (from o in dbContext.Orders where o.OrderID == id select o).ToList();
            }
        }
        
        public IEnumerable<Order> GetOrdersForCustomer(string customerId)
        {
            using (var dbContext = new NorthwindDbContext())
            {
                return (from o in dbContext.Orders where o.CustomerID == customerId select o);
            }
        }

        /// <summary>Die Routen f�r den aktuellen Controller hinzuf�gen</summary>
        public static void AddRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute(name: "OrdersForCustomer",
                                routeTemplate: "customers/{customerId}/orders",
                                defaults: new { controller = "Orders", action = "GetOrdersForCustomer" });


        }
    }
}