using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login(string user, string password)
        {
            //Code below is printing the inputs into console
            Console.WriteLine(user);
            Console.WriteLine(password);
            return View();
        }

        public IActionResult Register(string user, string password, string email, 
            string country, string state, string street, string zip)
        {
            // Code below is printing the inputs into console
            Console.WriteLine(user);
            Console.WriteLine(password);
            Console.WriteLine(email);
            Console.WriteLine(country);
            Console.WriteLine(state);
            Console.WriteLine(street);
            Console.WriteLine(zip);
            return View();
        }
    }
}
