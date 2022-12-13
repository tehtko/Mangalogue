using Mangalogue.Entities;
using Mangalogue.Models;
using Mangalogue.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mangalogue.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["User"] = HttpContext.Session.GetString("user");

            return View();
        }

        public IActionResult MangaList(string filter)
        {
            switch (filter)
            {
                case "new":
                    break;
                case "popular":
                    break;
                case "random":
                    break;
                default:
                    break;
            }
            return View();
        }

        public IActionResult Changelog()
        {
            return View(Enumerable.Empty<Changelog>());
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