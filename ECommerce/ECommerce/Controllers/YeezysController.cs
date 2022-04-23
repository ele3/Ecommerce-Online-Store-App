using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class YeezysController : Controller
    {
        public IActionResult Yeezys()
        {
            return View();
        }
    }
}
