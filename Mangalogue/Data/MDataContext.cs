using Microsoft.EntityFrameworkCore;

namespace Mangalogue.Data
{
    public class MDataContext : DbContext
    {
        public MDataContext(DbContextOptions<MDataContext> options) 
            : base(options)
        {
        }
    }
}
