using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.WebApi;
using Northwind.WebApi.Controllers;
using Northwind.WebApi.Models;

namespace Northwind.WebApi.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTest
    {
        [TestMethod]
        [DeploymentItem(@"Northwind.WebApi\App_Data\Northwind.sdf", @"App_Data")]
        public void Get()
        {
            // Arrange
            CustomersController controller = new CustomersController();

            // Act
            IEnumerable<Customer> result = controller.Get();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }


    }
}
