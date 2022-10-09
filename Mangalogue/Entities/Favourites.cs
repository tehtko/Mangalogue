using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Mangalogue.Entities
{
    public class Favourites
    {
        [Key]
        public int Id { get; set; }
        public Manga Manga { get; set; }
    }
}
