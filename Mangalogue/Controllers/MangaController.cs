using Mangalogue.Entities;
using Mangalogue.Models;
using Mangalogue.Services;
using Mangalogue.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Mangalogue.Controllers
{
    public class MangaController : Controller
    {
        private readonly MangaService _mangaService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MangaController(MangaService mangaService, IWebHostEnvironment webHostEnvironment)
        {
            _mangaService = mangaService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateManga(MangaCreationViewModel manga)
        {
            IFormFile file = manga.CoverImage;
            string _path = Path.Combine(_webHostEnvironment.WebRootPath, "Pages");
            string fileNameWithPath = Path.Combine(_path, file.FileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            byte[] data = System.IO.File.ReadAllBytes(fileNameWithPath);

            System.IO.File.Delete(fileNameWithPath);

            Manga _manga = new Manga
            {
                Title = manga.Title,
                Cover = data,
                Description = manga.Description,
                Genres = manga.Genres
            };

            // _mangaService create manga
            return View("AddChapter", _manga);

        }

        public IActionResult AddChapter(Manga manga)
        {
            ChapterUploadViewModel x = new();
            x.Manga = manga;
            return View(x);
        }

        [HttpPost]
        public IActionResult AddChapter(ChapterUploadViewModel manga)
        {
            List<Page> pages = new List<Page>();
            foreach (var file in manga.Pages)
            {
                var data = ImageConverter.ConvertToBinary(file, _webHostEnvironment);
                return View("test", Convert.ToBase64String(data));

                pages.Add(new Page
                {
                    Image = data
                });
            }


            Chapter chapter = new Chapter
            {
                ChapterNumber = manga.ChapterNumber,
                Pages = pages
            };

            Manga _manga = manga.Manga;
            _manga.Chapters.Add(chapter);

            // _mangaService update chapter

            return RedirectToAction("Index", "Home");
        }
    }
}
