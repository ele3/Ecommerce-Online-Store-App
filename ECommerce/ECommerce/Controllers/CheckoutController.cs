using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
