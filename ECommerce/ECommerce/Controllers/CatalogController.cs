using System.Net;
using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Newtonsoft.Json;
using System.Linq;

namespace ECommerce.Controllers
{
    public class CatalogController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        [HttpGet]
        public IActionResult Crocs()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Accessories()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Jordans()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Yeezys()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crocs(string selectedProduct)
        {
            if (selectedProduct != null && HttpContext.Session.GetString("UserSession") != null)
            {
                User userObject = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                AddToCart(selectedProduct, userObject);
                return RedirectToAction("Cart", "Cart");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Accessories(string selectedProduct)
        {
            if (selectedProduct != null && HttpContext.Session.GetString("UserSession") != null)
            {
                User userObject = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                AddToCart(selectedProduct, userObject);
                return RedirectToAction("Cart", "Cart");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Jordans(string selectedProduct)
        {
            if (selectedProduct != null && HttpContext.Session.GetString("UserSession") != null)
            {
                User userObject = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                AddToCart(selectedProduct, userObject);
                return RedirectToAction("Cart", "Cart");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Yeezys(string selectedProduct)
        {
            if (selectedProduct != null && HttpContext.Session.GetString("UserSession") != null)
            {
                User userObject = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                AddToCart(selectedProduct, userObject);
                return RedirectToAction("Cart", "Cart");
            }
            return View();
        }

        public Cart CheckCart(User userObject)
        {
            Cart cartObject = db.Carts.Where(x => x.UserId.Equals(userObject.UserId)).SingleOrDefault();
            if (cartObject != null)
            {
                return cartObject;
            }
            else
            {
                return null;
            }
        }

        public Cartproduct CheckCartproduct(int selectedProductId, Cart userCart)
        {
            Cartproduct cartproductObject = db.Cartproducts
                .Where(x => x.ProductId.Equals(selectedProductId) && x.CartId.Equals(userCart.CartId))
                .SingleOrDefault();
            if (cartproductObject != null)
            {
                return cartproductObject;
            }
            else
            {
                return null;
            }
        }

        public void AddToCart(String selectedProduct, User userObject)
        {
            int selectedProductId = int.Parse(selectedProduct);
            Cart userCart = CheckCart(userObject);

            // Increments the Quantity if the Cart Product has been found
            Cartproduct findCartProduct = CheckCartproduct(selectedProductId, userCart);
            if (findCartProduct != null)
            {
                db.Cartproducts.Find(findCartProduct.CartProductId).Quantity += 1;
                db.SaveChanges();
            }
            else
            {
                Cartproduct cartProductObject = new Cartproduct();
                cartProductObject.CartId = userCart.CartId;
                cartProductObject.ProductId = selectedProductId;
                cartProductObject.Quantity = 1;
                db.Cartproducts.Add(cartProductObject);
                db.SaveChanges();
            }
        }
    }
}