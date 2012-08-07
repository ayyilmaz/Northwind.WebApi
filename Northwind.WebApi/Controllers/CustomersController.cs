using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Northwind.WebApi.Models;

namespace Northwind.WebApi.Controllers
{
    public class CustomersController : ApiController
    {
        public IEnumerable<Customer> Get()
        {
            using(var dbContext = new NorthwindDbContext())
            {
                var customers =  dbContext.Customers.ToList();

                return customers;
            }            
        }
    }
}