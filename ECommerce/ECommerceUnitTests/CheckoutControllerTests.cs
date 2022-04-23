using ECommerce.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerceUnitTests
{
    [TestClass]
    public class CheckoutControllerTests
    {
        [TestMethod]
        public void Checkout_Does_Not_Return_Null()
        {
            CheckoutController testController = new CheckoutController();
            ViewResult result = testController.Checkout() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
