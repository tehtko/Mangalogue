namespace Mangalogue.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public ICollection<Manga>? Favourites { get; set; }
        public ICollection<Manga>? Posts { get; set; }
    }
}
