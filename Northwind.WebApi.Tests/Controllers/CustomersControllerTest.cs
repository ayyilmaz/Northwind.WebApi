using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
//        [DeploymentItem(@"Northwind.WebApi\App_Data\Northwind.sdf", @"App_Data")]
        [DeploymentItem(@"App_Data\Northwind.sdf", @"App_Data")]
        public void Get()
        {
            // Arrange
            CustomersController controller = new CustomersController();

            // Act
            IEnumerable<Customer> result = controller.Get();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
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
                var response = httpClient.GetAsync("customers").Result;
                var customers = response.Content.ReadAsAsync<List<Customer>>().Result;

                Assert.IsNotNull(customers);
                Assert.AreNotEqual(0, customers.Count);
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message);
                Assert.Fail(exception.Message);
            }


        }


    }
}
