using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Northwind.WebApi.Models;

namespace Northwind.WebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (var dbContext = new NorthwindDbContext())
            {
                return dbContext.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (var dbContext = new NorthwindDbContext())
            {
                return (from employee in dbContext.Employees where employee.EmployeeId == id select employee).FirstOrDefault();
            }           
        } 
    }
}