using Mangalogue.Helpers;
using Microsoft.Build.Framework;
using Newtonsoft.Json;

namespace Mangalogue.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public byte[]? ProfileImage { get; set; } = ImageConverter.DefaultProfileImage();
        public string? About { get; set; } = string.Empty;

        public ICollection<Manga>? Posts { get; set; } = Enumerable.Empty<Manga>().ToList();
        public ICollection<Favourites>? Favorites { get; set; } = Enumerable.Empty<Favourites>().ToList();
    }
}
