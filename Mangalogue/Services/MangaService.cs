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

        
    }
}
