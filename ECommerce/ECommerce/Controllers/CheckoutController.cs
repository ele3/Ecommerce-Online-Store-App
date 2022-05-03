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
            CartDetail modelObject = new CartDetail();
            HashSet<Sale> saleList = new HashSet<Sale>();
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                userObject = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
            }
            if (userObject != null)
            {
                double? subtotalAmount = 0;
                double? discountPercentage = 0;
                double? discountAmount = 0;
                double? totalAmount = 0;
                double? tax = 0;

                Cart cartObject = db.Carts.Include(x => x.Cartproducts).Where(x => x.UserId == userObject.UserId).SingleOrDefault();
                foreach (var cartProductObject in cartObject.Cartproducts)
                {
                    Product placeholderProduct = db.Products.Find(cartProductObject.ProductId);
                    cartProductObject.Product = placeholderProduct;
                    Sale? saleObject = db.Sales.Where(x => x.CategoryId == placeholderProduct.CategoryId).SingleOrDefault();
                    subtotalAmount += placeholderProduct.ProductPrice * cartProductObject.Quantity;
                    if (saleObject != null)
                    {
                        saleList.Add(saleObject);
                    }
                }

                if (saleList.Count != 0)
                {
                    modelObject.Sales = saleList;
                    foreach (var sale in saleList)
                    {
                        discountPercentage += sale.SalePercentDiscount;
                    }

                    modelObject.DiscountPercentage = discountPercentage;
                }

                modelObject.Cart = cartObject;
                discountAmount = Math.Round((double)subtotalAmount * (double)discountPercentage, 2);
                totalAmount = subtotalAmount - discountAmount;
                tax = Math.Round((double)totalAmount * 0.05, 2);
                totalAmount += tax;
                totalAmount = Math.Round((double)totalAmount, 2);
                discountPercentage *= 100;

                modelObject.DiscountAmount = discountAmount;
                modelObject.TotalAmount = totalAmount;
                modelObject.Tax = tax;
                modelObject.SubtotalAmount = subtotalAmount;
                modelObject.DiscountPercentage = discountPercentage;
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
