using Mangalogue.Entities;
using Mangalogue.Models;
using Mangalogue.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mangalogue.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel user)
        {
            // create a new User entity seperate from the front-end UserModel
            User _user = new User
            {
                Username = user.Username,
                Email = user.Username,
                Password = user.Password
            };

            // check to see if the User exists in the database with matching credentials
            if (_userService.Login(_user))
            {
                // create a session and return to homepage
                string userJson = JsonConvert.SerializeObject(_user);
                HttpContext.Session.SetString("user", userJson);

                return RedirectToAction("Index", "Home");
            }

            // tell the user that incorrect information was provided
            else
            {
                ViewData["LoginError"] = "Incorrect Username/Email or Password";
                return View();
            }
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(UserModel user)
        {
            // break out of the method if model state isn't valid
            if (!ModelState.IsValid)
            {
                return View();
            }

            // create a new User entity seperate from the front-end UserModel
            User _user = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };

            // try to add the user and log them in if successful
            if (_userService.AddUser(_user))
            {
                // create a session and return to homepage
                string userJson = JsonConvert.SerializeObject(_user);
                HttpContext.Session.SetString("user", userJson);

                return RedirectToAction("Index", "Home");
            }

            // throw a generic error to the user and send them back to the signup page
            else
            {
                ViewData["SignupError"] = "The username is already taken";
                return View();
            }
        }

        public IActionResult Profile()
        {
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }
    }
}
