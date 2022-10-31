using Mangalogue.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Mangalogue.Models
{
    public class MangaCreationViewModel
    {
        public string? Title { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public string? Description { get; set; }
        [BindProperty]
        public ICollection<Genres>? Genres { get; set; }
    }
}
