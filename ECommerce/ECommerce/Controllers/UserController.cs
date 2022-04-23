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

        [HttpGet]
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

        [HttpPost]
        public IActionResult Register(User newUserInfo)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new ECommerceContext())
                {
                    State state = new State
                    {
                        State1 = newUserInfo.Address.State.State1
                    };
                    dbContext.States.Add(state);
                    dbContext.SaveChanges();

                    var stateq =(from s in dbContext.States where s.State1 == newUserInfo.Address.State.State1
                        select s.StateId).ToArray();

                    Country country = new Country
                    {
                        Country1 = newUserInfo.Address.Country.Country1
                    };
                    dbContext.Countries.Add(country);
                    dbContext.SaveChanges();

                    var countryq = (from c in dbContext.Countries
                        where c.Country1 == newUserInfo.Address.Country.Country1
                        select c.CountryId).ToArray();

                    Address address = new Address
                    {
                        Zip = newUserInfo.Address.Zip,
                        StreetAddress = newUserInfo.Address.StreetAddress,
                        City = newUserInfo.Address.City,
                        StateId = stateq.ElementAt(0),
                        CountryId = countryq.ElementAt(0)
                    };
                    dbContext.Addresses.Add(address);
                    dbContext.SaveChanges();


                    /*User user = new User //TODO: grab addressId from DB and create User
                    {
                        UserName = newUserInfo.UserName,

                    };*/
                    
                    //TODO: grab userId from DB and create email
                }
            }
            return View();
        }

    }
}
