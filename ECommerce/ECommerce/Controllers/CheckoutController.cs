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

        public class ViewModel
        {
            public Cart? Cart { get; set; }
            public IEnumerable<Sale>? Sales { get; set; }
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            User userObject = null;
            ViewModel modelObject = new ViewModel();
            HashSet<Sale> saleList = new HashSet<Sale>();
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
                    Sale? saleObject = db.Sales.Where(x => x.CategoryId == placeholderProduct.CategoryId).SingleOrDefault();
                    if (saleObject != null)
                    {
                        saleList.Add(saleObject);
                    }
                }

                if (saleList.Count != 0)
                {
                    modelObject.Cart = cartObject;
                    modelObject.Sales = saleList;
                    return View(modelObject);
                }

                modelObject.Cart = cartObject;
                return View(modelObject);
            }
            return View();
        }

        [HttpPost]
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
                    db.Cartproducts.Remove(cartProductObject);
                    db.SaveChanges();
                }

                return RedirectToAction("MainPage", "Home");
            }
            return RedirectToAction("MainPage", "Home");
        }
    }
}
