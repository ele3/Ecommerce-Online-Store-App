using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Catalog()
        {
            return View();
        }
        public IActionResult Crocs()
        {
            return View();
        }
        public IActionResult Accessories()
        {
            return View();
        }
        public IActionResult Jordans()
        {
            return View();
        }
        public IActionResult Yeezys()
        {
            return View();
        }



    }
}
