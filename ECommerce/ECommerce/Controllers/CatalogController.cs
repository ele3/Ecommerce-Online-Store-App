using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Catalog()
        {
            return View();
        }
    }
}
