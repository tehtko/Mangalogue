using Mangalogue.Models;
using Mangalogue.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mangalogue.Controllers
{
    public class HomeController : Controller
    {

        public MangaService _mangaService { get; set; }
        public UserService _userService { get; set; }

        public HomeController(UserService userService, MangaService mangaService)
        {
            _userService = userService;
            _mangaService = mangaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}