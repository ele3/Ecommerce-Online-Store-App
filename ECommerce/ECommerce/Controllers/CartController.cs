using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        private ECommerceContext db = new ECommerceContext();
        public IActionResult Cart()
        {
            User userObject = null;
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                userObject = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
            }

            if (userObject != null)
            {
                double? cartTotal = 0;
                Cart cartObject = db.Carts.Include(x => x.Cartproducts).Where(x => x.UserId == userObject.UserId).SingleOrDefault();
                foreach (var cartProductObject in cartObject.Cartproducts)
                {
                    Product placeholderProduct = db.Products.Find(cartProductObject.ProductId);
                    cartProductObject.Product = placeholderProduct;

                    //below are changes to sum the products in a cart
                    double? sum = placeholderProduct.ProductPrice * cartProductObject.Quantity;
                    cartTotal += sum;
                }
                cartObject.CartTotal = cartTotal;

                return View(cartObject);
            }
            return View();
        }
    }
}
