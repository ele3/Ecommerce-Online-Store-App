using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class UserController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

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
            //code below takes values in the DB and prints them to the console
            var mydata = db.States.Select(x => x.State1).ToList();
            foreach (var VARIABLE in mydata)
            {
                Console.WriteLine(VARIABLE);
            }
            //code below adds states to the DB
            if (state != null)
            {
                State state2 = new State
                {
                    State1 = state
                };
                db.States.Add(state2);
                db.SaveChanges();
            }
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
