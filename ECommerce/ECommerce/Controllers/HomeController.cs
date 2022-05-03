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
                CatalogController catalogController = new CatalogController();
                catalogController.AddToCart(selectedProduct, userObject);
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