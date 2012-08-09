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
        public void Get()
        {
            // Arrange
            OrdersController controller = new OrdersController();

            // Act
//            IEnumerable<Order> result = controller.GetOrdersForCustomer("ALFKI");

            // Assert
//            Assert.IsNotNull(result);
//            Assert.IsTrue(result.Any());
//            Assert.AreEqual("ALFKI", result.First().CustomerID);
////            Assert.IsNotNull(result.First().OrderDetails);
        }


    }
}