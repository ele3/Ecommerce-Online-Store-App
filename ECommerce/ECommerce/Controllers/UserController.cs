using System.Diagnostics.Eventing.Reader;
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string user, string password)
        {
            if (user != null && password != null)
            {
                User userObject = CheckUser(user, password);
                if (userObject != null)
                {
                    HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(userObject));

                    return RedirectToAction("MainPage", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(string firstName, string lastName, string user, string password, 
            string email, string country, string state, string city, string street, string zip)
        {

            var dbState = db.States.Where(x => x.State1 == state).SingleOrDefault();
            var dbCountry = db.Countries.Where(x => x.Country1 == country).SingleOrDefault();
            var dbAddress = db.Addresses.Where(x => x.StreetAddress == street).SingleOrDefault();
            var dbUser = db.Users.Where(x => x.UserName == user).SingleOrDefault();

            if (state != null && dbState ==null)
            {
                State newState = new State
                {
                    State1 = state
                };
                db.States.Add(newState);
                db.SaveChanges();
                dbState = db.States.Where(x => x.State1 == state).SingleOrDefault();
            }

            if (country !=null && dbCountry == null)
            {
                Country newCountry = new Country
                {
                    Country1 = country
                };
                db.Countries.Add(newCountry);
                db.SaveChanges();
                dbCountry = db.Countries.Where(x => x.Country1 == country).SingleOrDefault();
            }

            if (street != null && city != null && zip != null && dbAddress == null)
            {
                Address newAddress = new Address
                {
                    StreetAddress = street,
                    Zip = zip,
                    City = city,
                    StateId = dbState.StateId,
                    CountryId = dbCountry.CountryId
                };
                db.Addresses.Add(newAddress);
                db.SaveChanges();
                dbAddress = db.Addresses.Where(x => x == newAddress).SingleOrDefault();
            }

            if (user != null && dbUser == null)
            {
                User newUser = new User
                {
                    UserName = user,
                    UserPassword = password,
                    FirstName = firstName,
                    LastName = lastName,
                    UserPhoneNumber = null,
                    AddressId = dbAddress.AddressId
                };
                db.Users.Add(newUser);
                db.SaveChanges();
                dbUser = db.Users.Where(x => x == newUser).SingleOrDefault();
                Cart newCart = new Cart
                {
                    UserId = dbUser.UserId
                };
                db.Carts.Add(newCart);
                db.SaveChanges();
                Email newEmail = new Email
                {
                    Address = email,
                    UserId = dbUser.UserId
                };
                db.Emails.Add(newEmail);
                db.SaveChanges();
            }
            return RedirectToAction("Login", "User");
        }


        public User CheckUser(string user, string password)
        {
            User userObject = db.Users.Where(x => x.UserName.Equals(user) && x.UserPassword.Equals(password)).SingleOrDefault();
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
