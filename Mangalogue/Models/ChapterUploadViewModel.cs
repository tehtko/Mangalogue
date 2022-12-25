using Mangalogue.Entities;

namespace Mangalogue.Models
{
    public class ChapterUploadViewModel
    {
        public int MangaId { get; set; }
        public ICollection<IFormFile>? Pages { get; set; }
    }
}
