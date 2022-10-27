namespace Mangalogue.Entities
{
    public class Chapter
    {
        public int Id { get; set; }
        public ICollection<Page>? Pages { get; set; }
    }
}
