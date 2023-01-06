using Mangalogue.Entities;
using Mangalogue.Models;
using Mangalogue.Services;
using Mangalogue.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using Westwind.Web;

namespace Mangalogue.Controllers
{
    public class MangaController : Controller
    {
        private readonly MangaService _mangaService;
        private readonly SessionManager _sessionManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MangaController(MangaService mangaService, SessionManager sessionManager, IWebHostEnvironment webHostEnvironment)
        {
            _mangaService = mangaService;
            _webHostEnvironment = webHostEnvironment;
            _sessionManager = sessionManager;
        }

        public IActionResult CreateManga()
        {
            if (_sessionManager.GetUserSession() is null)
                return RedirectToAction("Login", "User");

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
                Genres = manga.Genres,
                AuthorId = _sessionManager.GetUserSession().Id
            };

            ChapterUploadViewModel x = new ChapterUploadViewModel
            {
                MangaId = _mangaService.GetMangaByTitle(_manga.Title).Id
            };

            // add hidden input for manga id and get manga in AddChapter method
            return View("AddChapter", x);
        }

        [HttpPost]
        public IActionResult AddChapter(int mangaId, List<IFormFile> pages)
        {
            var _manga = _mangaService.GetMangaById(mangaId);

            // make sure the user trying to add a chapter to the manga is the author
            if (_sessionManager.GetUserSession().Id != _manga.AuthorId)
                return RedirectToAction("Index", "Home");

            // create an empty list of pages, that the chapter will contain
            List<Page> _pages = new List<Page>();

            // add each image to the pages list
            foreach (var file in pages)
            {
                var data = ImageConverter.ConvertToBinary(file, _webHostEnvironment);

                _pages.Add(new Page
                {
                    Image = data
                });
            }

            // get the current chapter number and increment by 1
            // then store all those pages into said chapter
            Chapter chapter = new Chapter
            {
                ChapterNumber = _manga.Chapters.Count + 1,
                Pages = _pages
            };

            // and add that chapter to the manga
            _manga.Chapters.Add(chapter);

            // update the manga
            _mangaService.UpdateManga(_manga); // if it doesn't exist, it will create it

            return RedirectToAction("Profile", "User");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
