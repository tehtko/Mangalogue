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

        public IActionResult CreateManga()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateManga(MangaCreationViewModel manga)
        {
            IFormFile file = manga.Thumbnail;
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
                Thumbnail = data,
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

            _mangaService.CreateManga(manga);
            return View(x);
        }

        [HttpPost]
        public IActionResult AddChapter(ChapterUploadViewModel manga)
        {
            List<Page> pages = new List<Page>();

            // add each image to the pages list
            foreach (var file in manga.Pages)
            {
                var data = ImageConverter.ConvertToBinary(file, _webHostEnvironment);

                pages.Add(new Page
                {
                    Image = data
                });
            }

            // then store all those pages into a single chapter
            Chapter chapter = new Chapter
            {
                ChapterNumber = manga.ChapterNumber,
                Pages = pages
            };

            // and add that chapter to the manga
            Manga _manga = manga.Manga;
            _manga.Chapters.Add(chapter);

            return RedirectToAction("Index", "Home");
        }
    }
}
