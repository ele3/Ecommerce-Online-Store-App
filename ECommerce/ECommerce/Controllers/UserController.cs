using System.Net;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.Controllers
{
    public class UserController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        public IActionResult Login(string user, string password)
        {
            if (user != null && password != null)
            {
                User userObject = CheckUser(user, password);
                if (userObject != null)
                {
                    HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(userObject));

                    // This here below is how you call the Session Object
                    User testUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                    Console.WriteLine(testUser.UserId);
                    Console.WriteLine(testUser.UserName);
                    Console.WriteLine(testUser.UserPassword);

                    return RedirectToAction("MainPage", "Home");
                }
            }
            return View();
        }

        public IActionResult Register(string firstName, string lastName, string user, string password, 
            string email, string country, string state, string city, string street, string zip)
        {
            //code below takes values in the DB and prints them to the console
            var listOfSatates = db.States.Select(x => x.State1).ToList();
            foreach (var VARIABLE in listOfSatates)
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


        public User CheckUser(string user, string password)
        {
            User userObject = db.Users.Where(query => query.UserName.Equals(user) && query.UserPassword.Equals(password)).SingleOrDefault();
            if (userObject == null)
            {
                return null;
            }
            else
            {
                return userObject;
            }
        }
    }
}
