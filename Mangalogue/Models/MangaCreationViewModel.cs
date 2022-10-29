using Mangalogue.Helpers;

namespace Mangalogue.Models
{
    public class MangaCreationViewModel
    {
        public string? Title { get; set; }
        public IFormFile? CoverImage { get; set; }
        public string? Description { get; set; }
        public ICollection<Genres>? Genres { get; set; }
    }
}
