using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Northwind.WebApi.Models;

namespace Northwind.WebApi.Controllers
{
    public class SuppliersController : ApiController
    {
        public IEnumerable<Supplier> Get()
        {
            using (var dbContext = new NorthwindDbContext())
            {
                return dbContext.Suppliers.ToList();
            }
        }
    }
}