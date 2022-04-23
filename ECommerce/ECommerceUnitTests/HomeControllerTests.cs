using ECommerce.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerceUnitTests
{
    [TestClass]
    public class HomeControllerTests
    {
        private readonly ILogger<HomeController> _logger;
        [TestMethod]
        public void Index_Does_Not_Return_Null()
        {
            HomeController testController = new HomeController(_logger);
            ViewResult result = testController.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Privacy_Does_Not_Return_Null()
        {
            HomeController testController = new HomeController(_logger);
            ViewResult result = testController.Privacy() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MainPage_Does_Not_Return_Null()
        {
            HomeController testController = new HomeController(_logger);
            ViewResult result = testController.MainPage() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}