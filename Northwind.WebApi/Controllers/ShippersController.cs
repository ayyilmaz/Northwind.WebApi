using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Northwind.WebApi.Models;

namespace Northwind.WebApi.Controllers
{
    public class ShippersController : ApiController
    {
        public IEnumerable<Shipper> Get()
        {
            using (var dbContext = new NorthwindDbContext())
            {
                return dbContext.Shippers.ToList();
            }
        }
    }
}