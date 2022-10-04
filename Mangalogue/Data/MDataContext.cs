using Mangalogue.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mangalogue.Data
{
    public class MDataContext : DbContext
    {
        public MDataContext(DbContextOptions<MDataContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Manga> Mangas { get; set; }
    }
}
