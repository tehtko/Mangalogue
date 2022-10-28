using Mangalogue.Entities;
using Mangalogue.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Mangalogue.Data
{
    public class MDataContext : DbContext
    {
        public MDataContext(DbContextOptions<MDataContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Manga>()
                .Property(x => x.Genres)
                .HasConversion(
                v => v.ToString(),
                v => (ICollection<Genres>)Enum.Parse(typeof(ICollection<Genres>), v));

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<Favourites> Favourites { get; set; }
    }
}
