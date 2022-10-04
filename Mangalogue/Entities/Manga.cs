namespace Mangalogue.Entities
{
    public class Manga
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<string>? Pages { get; set; }
        public ICollection<string>? Genres { get; set; }

        public User Author { get; set; }
    }
}
