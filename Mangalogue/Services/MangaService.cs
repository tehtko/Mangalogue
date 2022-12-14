using Mangalogue.Data;
using Mangalogue.Entities;

namespace Mangalogue.Services
{
    public class MangaService
    {
        private readonly MDataContext _context;
        public MangaService(MDataContext context)
        {
            _context = context;
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
            int mangaCount = _context.Mangas.ToList().Count;
            return _context.Mangas.OrderBy(m=>m.CreatedDate).Take(mangaCount).ToList();
        }

        public List<Manga> GetPopularManga()
        {
            int mangaCount = _context.Mangas.ToList().Count;
            return _context.Mangas.OrderBy(m => m.ViewCount).Take(mangaCount).ToList();
        }

        public List<Manga> GetRandomManga()
        {
            int mangaCount = _context.Mangas.ToList().Count;
            return _context.Mangas.OrderBy(arg => Guid.NewGuid()).Take(mangaCount).ToList();
        }
    }
}
