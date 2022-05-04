using ECommerce.Controllers;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerceUnitTests
{
    [TestClass]
    public class CartControllerTests
    {
        [TestMethod]
        public void CalculateAmounts_Returns_Correct_Values()
        {
            CartController testController = new CartController();
            CartDetail testCalculations = testController.CalculateAmounts(937, 0.15);
            CartDetail correctCalculations = new CartDetail();
            correctCalculations.SubtotalAmount = 937;
            correctCalculations.TotalAmount = 836.27;
            correctCalculations.DiscountPercentage = 15;
            correctCalculations.DiscountAmount = 140.55;
            correctCalculations.Tax = 39.82;
            correctCalculations.Cart = null;
            correctCalculations.Sales = null;
            Assert.AreEqual(testCalculations.SubtotalAmount, correctCalculations.SubtotalAmount);
            Assert.AreEqual(testCalculations.TotalAmount, correctCalculations.TotalAmount);
            Assert.AreEqual(testCalculations.DiscountAmount, correctCalculations.DiscountAmount);
            Assert.AreEqual(testCalculations.DiscountPercentage, correctCalculations.DiscountPercentage);
            Assert.AreEqual(testCalculations.Tax, correctCalculations.Tax);
        }
    }
}