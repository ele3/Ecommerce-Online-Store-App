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
            ViewResult result = testController.Login("Username", "Password") as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Register_Does_Not_Return_Null()
        {
            UserController testController = new UserController();
            ViewResult result = testController.Register("Username", "Password",
                "Email", "Country", "State", "Street", "Zip") as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
