using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Checkout(string cardholderName, string cardNumber, string month, string year, string cvv)
        {
            Console.WriteLine(cardholderName);
            Console.WriteLine(cardNumber);
            Console.WriteLine(month);
            Console.WriteLine(year);
            Console.WriteLine(cvv);
            return View();
        }
    }
}
