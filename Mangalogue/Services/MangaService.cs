using Mangalogue.Data;
using Mangalogue.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mangalogue.Services
{
    public class MangaService
    {
        private readonly MDataContext _context;
        public MangaService(MDataContext context)
        {
            _context = context;
        }

        public Manga GetMangaById(int id)
        {
            return _context.Mangas.FirstOrDefault(m => m.Id == id);
        }

        public Manga GetMangaByTitle(string title)
        {
            return _context.Mangas.FirstOrDefault(m => m.Title == title);
        }

        public void CreateManga(Manga manga)
        {
            if (manga is null)
                return;

            _context.Mangas.Add(manga);
            _context.SaveChanges();
        }

        public void UpdateManga(Manga manga)
        {
            if (manga is null)
                return;

            _context.Mangas.Update(manga);
            _context.SaveChanges();
        }

        public List<Manga> GetNewestManga()
        {
            try
            {
                int mangaCount = _context.Mangas.ToList().Count;
                return _context.Mangas.OrderBy(m => m.CreatedDate).Take(mangaCount).ToList();
            }
            catch (ArgumentNullException)
            {
                return Enumerable.Empty<Manga>().ToList();
            }
        }

        public List<Manga> GetPopularManga()
        {
            try
            {
                int mangaCount = _context.Mangas.ToList().Count;
                return _context.Mangas.OrderBy(m => m.ViewCount).Take(mangaCount).ToList();
            }
            catch (ArgumentNullException)
            {
                return Enumerable.Empty<Manga>().ToList();
            }
        }

        public List<Manga> GetRandomManga()
        {
            try
            {
                int mangaCount = _context.Mangas.ToList().Count;
                return _context.Mangas.OrderBy(arg => Guid.NewGuid()).Take(mangaCount).ToList();
            }
            catch (ArgumentNullException)
            {
                return Enumerable.Empty<Manga>().ToList();
            }
        }
    }
}
