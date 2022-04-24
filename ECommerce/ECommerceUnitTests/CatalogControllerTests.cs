using ECommerce.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerceUnitTests
{
    [TestClass]
    public class CatalogControllerTests
    {
        [TestMethod]
        public void Crocs_Does_Not_Return_Null()
        {
            CatalogController testController = new CatalogController();
            ViewResult result = testController.Crocs("1") as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Accessories_Does_Not_Return_Null()
        {
            CatalogController testController = new CatalogController();
            ViewResult result = testController.Accessories("1") as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Jordans_Does_Not_Return_Null()
        {
            CatalogController testController = new CatalogController();
            ViewResult result = testController.Jordans("1") as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Yeezys_Does_Not_Return_Null()
        {
            CatalogController testController = new CatalogController();
            ViewResult result = testController.Yeezys("1") as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
