using Mangalogue.Entities;
using Mangalogue.Helpers;
using Mangalogue.Models;
using Mangalogue.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace Mangalogue.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly SessionManager _sessionManager;

        public UserController(UserService userService, SessionManager sessionManager)
        {
            _userService = userService;
            _sessionManager = sessionManager;
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
                // create a session and return to profile view
                _sessionManager.CreateUserSession(_user);
                return RedirectToAction("Profile");
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
                // create a session and return to profile view
                _sessionManager.CreateUserSession(_user);
                return RedirectToAction("Profile");
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
            var user = _sessionManager.GetUserSession();

            if(user is null)
                return RedirectToAction("Index", "Home");

            return View(user);
        }

        [HttpGet("/Profile/{id}")]
        public IActionResult Profile(int id)
        {
            var user = _userService.GetUserById(id);

            if (user is null)
                return RedirectToAction("Index", "Home");

            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }
    }
}
