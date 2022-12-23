using Mangalogue.Entities;

namespace Mangalogue.Models
{
    public class ChapterUploadViewModel
    {
        public Manga Manga { get; set; }
        public ICollection<IFormFile>? Pages { get; set; }
    }
}
