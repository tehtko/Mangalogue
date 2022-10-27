using System.ComponentModel.DataAnnotations.Schema;

namespace Mangalogue.Entities
{
    public class Manga
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Cover { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<Chapter>? Chapters { get; set; }

        public User Author { get; set; }
    }
}
