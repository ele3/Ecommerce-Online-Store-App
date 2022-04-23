using ECommerce.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerceUnitTests
{
    [TestClass]
    public class CartControllerTests
    {
        [TestMethod]
        public void Cart_Does_Not_Return_Null()
        {
            CartController testController = new CartController();
            ViewResult result = testController.Cart() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
