using ECommerce.Models;
using ECommerce.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ECommerce.Data;
using Newtonsoft.Json;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ECommerceContext db = new ECommerceContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MainPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MainPage(string? selectedProduct)
        {

            if (selectedProduct != null && HttpContext.Session.GetString("UserSession") != null)
            {
                User userObject = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                int selectedProductId = int.Parse(selectedProduct);
                CatalogController catalogController = new CatalogController();
                Cart userCart = catalogController.CheckCart(userObject);

                // Increments the Quantity if the Cart Product has been found
                Cartproduct findCartproduct = catalogController.CheckCartproduct(selectedProductId, userCart);
                if (findCartproduct != null)
                {
                    db.Cartproducts.Find(findCartproduct.CartProductId).Quantity += 1;
                    db.SaveChanges();
                    return RedirectToAction("Cart", "Cart");
                }

                Cartproduct cartProductObject = new Cartproduct();
                cartProductObject.CartId = userCart.CartId;
                cartProductObject.ProductId = selectedProductId;
                cartProductObject.Quantity = 1;
                db.Cartproducts.Add(cartProductObject);
                db.SaveChanges();
                return RedirectToAction("Cart", "Cart");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}