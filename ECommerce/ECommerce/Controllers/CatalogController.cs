using System.Net;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.Controllers
{
    public class CatalogController : Controller
    {
        private ECommerceContext db = new ECommerceContext();
        public IActionResult Crocs(string selectedProduct)
        {
            // Prints out the Primary ID of the Selected Product
            if (selectedProduct != null)
            {
                int selectedProductId = int.Parse(selectedProduct);
                //queries the db for the product with the selectedProductId and returns a var of product type
                var product = (from p in db.Products where p.ProductId==selectedProductId select p ).FirstOrDefault();
                Console.WriteLine(product.ProductName);
                Console.WriteLine(selectedProduct);
            }
            return View();
        }
        public IActionResult Accessories(string selectedProduct)
        {
            // Prints out the Primary ID of the Selected Product
            if (selectedProduct != null)
            {
                int selectedProductId = int.Parse(selectedProduct);
                Console.WriteLine(selectedProduct);
            }
            return View();
        }
        public IActionResult Jordans(string selectedProduct)
        {
            // Prints out the Primary ID of the Selected Product
            if (selectedProduct != null)
            {
                int selectedProductId = int.Parse(selectedProduct);
                Console.WriteLine(selectedProduct);
            }
            return View();
        }
        public IActionResult Yeezys(string selectedProduct)
        {
            // Prints out the Primary ID of the Selected Product
            if (selectedProduct != null)
            {
                int selectedProductId = int.Parse(selectedProduct);
                Console.WriteLine(selectedProduct);
            }
            return View();
        }



    }
}
