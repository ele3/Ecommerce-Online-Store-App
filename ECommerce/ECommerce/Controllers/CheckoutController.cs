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
        public IActionResult Checkout(string cardholderName, string cardNumber, string month, string year, string cvv)
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
    }
}
