namespace Mangalogue.Models
{
    public class ChapterUploadViewModel
    {
        public int ChapterNumber { get; set; }
        public ICollection<IFormFile>? Pages { get; set; }
    }
}
