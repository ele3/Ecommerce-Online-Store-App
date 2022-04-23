using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class JordansController : Controller
    {
        public IActionResult Jordans()
        {
            return View();
        }
    }
}
