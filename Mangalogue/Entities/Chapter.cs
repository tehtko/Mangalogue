namespace Mangalogue.Entities
{
    public class Chapter
    {
        public int Id { get; set; }
        public int ChapterNumber { get; set; }
        public ICollection<Page>? Pages { get; set; } = Enumerable.Empty<Page>().ToList();
    }
}
