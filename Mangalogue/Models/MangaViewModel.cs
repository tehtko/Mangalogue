using Mangalogue.Entities;

namespace Mangalogue.Models
{
    public class MangaViewModel
    {
        public ICollection<Manga>? Newest { get; set; }
        public ICollection<Manga>? MostPopular { get; set; }
        public ICollection<Manga>? Trending { get; set; }
    }
}
