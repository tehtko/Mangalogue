﻿using Microsoft.Build.Framework;

namespace Mangalogue.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }

        public ICollection<Manga>? Posts { get; set; }
        public ICollection<Favourites>? Favorites { get; set; }
    }
}
