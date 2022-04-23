using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CrocsController : Controller
    {
        public IActionResult Crocs()
        {
            return View();
        }
    }
}
