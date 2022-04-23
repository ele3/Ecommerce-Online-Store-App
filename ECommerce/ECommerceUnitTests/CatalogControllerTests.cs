using ECommerce.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerceUnitTests
{
    [TestClass]
    public class CatalogControllerTests
    {
        [TestMethod]
        public void Catalog_Does_Not_Return_Null()
        {
            CatalogController testController = new CatalogController();
            ViewResult result = testController.Catalog() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
