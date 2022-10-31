using Mangalogue.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mangalogue.Entities
{
    public class Manga
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public byte[]? Thumbnail { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public ICollection<Chapter>? Chapters { get; set; }
        public string? Description { get; set; }
        public ICollection<Genres>? Genres { get; set; }

        public User? Author { get; set; }
    }
}
