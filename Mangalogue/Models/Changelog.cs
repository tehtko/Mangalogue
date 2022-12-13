namespace Mangalogue.Models
{
    public class Changelog
    {
        public int Id { get; set; }
        public DateOnly PostDate { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
