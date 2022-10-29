using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Mangalogue.Helpers
{
    public class ImageConverter
    {
        public static byte[] ConvertToBinary(IFormFile image, IWebHostEnvironment _webHostEnvironment)
        {
            string _path = Path.Combine(_webHostEnvironment.WebRootPath, "Pages");
            string fileNameWithPath = Path.Combine(_path, image.FileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            byte[] data = File.ReadAllBytes(fileNameWithPath);

            System.IO.File.Delete(fileNameWithPath);

            return data;
        }

        public static void ConvertToImage(string path, byte[] image)
        {
            System.IO.File.WriteAllBytes(path, image);
        }
    }
}
