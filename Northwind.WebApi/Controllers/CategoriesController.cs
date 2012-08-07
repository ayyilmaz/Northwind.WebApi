using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Northwind.WebApi.Models;

namespace Northwind.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        public IEnumerable<Category> Get()
        {
            using (var dbContext = new NorthwindDbContext())
            {
                return dbContext.Categories.ToList();
            }
        }
    }
}