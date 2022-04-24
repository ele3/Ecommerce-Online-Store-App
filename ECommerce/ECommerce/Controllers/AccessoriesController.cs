using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class AccessoriesController : Controller
    {
        public IActionResult Accessories()
        {
            return View();
        }
    }
}
