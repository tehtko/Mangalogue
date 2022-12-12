using Mangalogue.Entities;
using Mangalogue.Models;
using Mangalogue.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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