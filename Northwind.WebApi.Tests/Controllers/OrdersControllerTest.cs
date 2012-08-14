using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

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
            Assert.IsTrue(result.First().OrderDetails.Count > 0);
        }

        /// <summary></summary>
        [TestMethod]
        [Description("")]
        public void GetOverHttp()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8888/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = httpClient.GetAsync("customers/ALFKI/orders").Result;
                response.EnsureSuccessStatusCode();
                var orders = response.Content.ReadAsAsync<List<Order>>().Result;

                Assert.IsNotNull(orders);
                Assert.AreNotEqual(0, orders.Count);
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message);
                Assert.Fail(exception.Message);
            }


        }


    }
}