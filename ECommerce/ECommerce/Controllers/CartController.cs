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
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                User userObject = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                CartDetail modelObject = getCartDetail(userObject);
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

        public CartDetail getCartDetail(User userObject)
        {
            CartDetail modelObject = new CartDetail();
            HashSet<Sale> saleList = new HashSet<Sale>();
            double? subtotalAmount = 0;
            double? discountPercentage = 0;

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

            CartDetail calculateAmounts = CalculateAmounts(subtotalAmount, discountPercentage);

            modelObject.DiscountAmount = calculateAmounts.DiscountAmount;
            modelObject.TotalAmount = calculateAmounts.TotalAmount;
            modelObject.Tax = calculateAmounts.Tax;
            modelObject.SubtotalAmount = subtotalAmount;
            modelObject.DiscountPercentage = discountPercentage;

            return modelObject;
        }

        public CartDetail CalculateAmounts(double? subtotalAmount, double? discountPercentage)
        {
            CartDetail modelObject = new CartDetail();
            double? discountAmount = Math.Round((double)subtotalAmount * (double)discountPercentage, 2);
            double? totalAmount = subtotalAmount - discountAmount;
            double? tax = Math.Round((double)totalAmount * 0.05, 2);
            totalAmount += tax;
            totalAmount = Math.Round((double)totalAmount, 2);
            discountPercentage *= 100;

            modelObject.DiscountAmount = discountAmount;
            modelObject.TotalAmount = totalAmount;
            modelObject.Tax = tax;
            modelObject.SubtotalAmount = subtotalAmount;
            modelObject.DiscountPercentage = discountPercentage;

            return modelObject;
        }
    }
}
