using Mangalogue.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mangalogue.Controllers
{
    public class MangaController : Controller
    {
        public MangaService _mangaService { get; set; }

        public MangaController(MangaService mangaService)
        {
            _mangaService = mangaService;
        }

        public IActionResult Login()
        {
            return View("Account");
        }

        public IActionResult Signup()
        {
            return View("Account");
        }

        public IActionResult Post()
        {
            return View();
        }
    }
}
