using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Northwind.WebApi.Controllers;
using Northwind.WebApi.Models;

namespace Northwind.WebApi.Tests.Controllers
{
    [TestClass]
    public class OrdersControllerTest
    {
        [TestMethod]
        [DeploymentItem(@"Northwind.WebApi\App_Data\Northwind.sdf", @"App_Data")]
        public void Get()
        {
            // Arrange
            OrdersController controller = new OrdersController();

            // Act
            IEnumerable<Order> result = controller.GetOrdersForCustomer("ALFKI");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreEqual("ALFKI", result.First().CustomerID);
        }


    }
}