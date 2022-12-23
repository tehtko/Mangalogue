using Mangalogue.Helpers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Security.Policy;

namespace Mangalogue.Entities
{
    public class Manga
    {
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public byte[]? Thumbnail { get; set; } = ImageConverter.DefaultProfileImage();
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public ICollection<Chapter> Chapters { get; set; } = Enumerable.Empty<Chapter>().ToList();
        public string? Description { get; set; } = string.Empty;
        public int? ViewCount { get; set; } = 0;
        public double? Rating { get; set; } = 0.0;
        public ICollection<Genres>? Genres { get; set; } = Enumerable.Empty<Genres>().ToList();

        public User? Author { get; set; }
    }
}
