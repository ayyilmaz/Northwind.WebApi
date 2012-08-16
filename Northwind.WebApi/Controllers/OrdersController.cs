using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
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
        
        public HttpResponseMessage GetOrdersForCustomer(string customerId)
        {
            try
            {
                using (var dbContext = new NorthwindDbContext())
                {
                    var orders = (from o in dbContext.Orders.Include("OrderDetails") where o.CustomerID == customerId select o).ToList();

                    return Request.CreateResponse(HttpStatusCode.OK, orders);
                }
            }
            catch (Exception exception)
            {
                new LogEvent(exception.Message).Raise();
            }

            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
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