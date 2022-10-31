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
    }
}
