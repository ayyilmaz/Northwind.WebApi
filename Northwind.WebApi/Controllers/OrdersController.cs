using System;
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
            try
            {
                using (var dbContext = new NorthwindDbContext())
                {
                    return (from o in dbContext.Orders.Include("OrderDetails") where o.CustomerID == customerId select o).ToList();
                }
            }
            catch (Exception exception)
            {
                new LogEvent(exception.Message).Raise();
            } 

            return new List<Order>();
        }

        /// <summary>Die Routen für den aktuellen Controller hinzufügen</summary>
        public static void AddRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute(name: "OrdersForCustomer",
                                routeTemplate: "customers/{customerId}/orders",
                                defaults: new { controller = "Orders", action = "GetOrdersForCustomer" });


        }
    }
}