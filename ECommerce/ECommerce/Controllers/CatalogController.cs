using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Catalog()
        {
            return View();
        }
        public IActionResult Crocs(string selectedProduct)
        {
            // Prints out the Primary ID of the Selected Product
            Console.WriteLine(selectedProduct);
            return View();
        }
        public IActionResult Accessories(string selectedProduct)
        {
            // Prints out the Primary ID of the Selected Product
            Console.WriteLine(selectedProduct);
            return View();
        }
        public IActionResult Jordans(string selectedProduct)
        {
            // Prints out the Primary ID of the Selected Product
            Console.WriteLine(selectedProduct);
            return View();
        }
        public IActionResult Yeezys(string selectedProduct)
        {
            // Prints out the Primary ID of the Selected Product
            Console.WriteLine(selectedProduct);
            return View();
        }



    }
}
