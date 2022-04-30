using ECommerce.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerceUnitTests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Login_Does_Not_Return_Null()
        {
            UserController testController = new UserController();
            ViewResult? result = testController.Login() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Register_Does_Not_Return_Null()
        {
            UserController testController = new UserController();
            ViewResult? result = testController.Register() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
