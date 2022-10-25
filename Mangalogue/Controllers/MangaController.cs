using Mangalogue.Models;
using Mangalogue.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mangalogue.Controllers
{
    public class MangaController : Controller
    {
        private readonly MangaService _mangaService;

        public MangaController(MangaService mangaService)
        {
            _mangaService = mangaService;
        }

        public IActionResult Post()
        {
            return View();
        }
    }
}
