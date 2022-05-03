﻿using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ECommerce.Controllers
{
    public class ViewModel
    {
        public Cart? Cart { get; set; }
        public IEnumerable<Sale>? Sales { get; set; }
    }
    public class CartController : Controller
    {
        private ECommerceContext db = new ECommerceContext();
        public IActionResult Cart()
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cartproduct cartProductObject = await db.Cartproducts.FirstOrDefaultAsync(x => x.CartProductId == id);
            if (cartProductObject == null)
            {
                return NotFound();
            }
            Product placeholderProduct = db.Products.Find(cartProductObject.ProductId);
            cartProductObject.Product = placeholderProduct;
            return View(cartProductObject);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Cartproduct cartProductObject = await db.Cartproducts.FindAsync(id);
            db.Cartproducts.Remove(cartProductObject);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Cart));
        }
    }
}
