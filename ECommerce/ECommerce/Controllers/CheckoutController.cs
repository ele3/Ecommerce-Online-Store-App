using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ECommerce.Controllers
{
    public class CheckoutController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        [HttpGet]
        public IActionResult Checkout()
        {
            User userObject = null;
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                userObject = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
            }
            if (userObject != null)
            {
                Cart cartObject = db.Carts.Include(x => x.Cartproducts).Where(x => x.UserId == userObject.UserId).SingleOrDefault();
                foreach (var cartProductObject in cartObject.Cartproducts)
                {
                    Product placeholderProduct = db.Products.Find(cartProductObject.ProductId);
                    cartProductObject.Product = placeholderProduct;
                }

                return View(cartObject);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(string cardholderName, string cardNumber, string month, string year, string cvv)
        {
            Console.WriteLine(cardholderName);
            User userObject = null;
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                userObject = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
            }
            if (userObject != null)
            {
                Cart cartObject = db.Carts.Include(x => x.Cartproducts).Where(x => x.UserId == userObject.UserId).SingleOrDefault();
                foreach (var cartProductObject in cartObject.Cartproducts)
                {
                    db.Cartproducts.Remove(cartProductObject);
                    db.SaveChanges();
                }

                return RedirectToAction("MainPage", "Home");
            }
            return RedirectToAction("MainPage", "Home");
        }
    }
}
