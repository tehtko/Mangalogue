using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Mangalogue.Helpers
{
    public class ImageConverter
    {
        public static byte[] ConvertToBinary(IFormFile image, IWebHostEnvironment _webHostEnvironment)
        {
            // get the path to store the image temporarily
            string _path = Path.Combine(_webHostEnvironment.WebRootPath, "Pages");

            // get the full file name and path
            string fileNameWithPath = Path.Combine(_path, image.FileName);

            // make sure a file with the same name doesn't already exist
            if (File.Exists(fileNameWithPath))
            {
                File.Delete(fileNameWithPath);
            }

            // save the image so we can read its data
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            // create a byte array with the images binary data
            byte[] data = File.ReadAllBytes(fileNameWithPath);

            // delete the image
            File.Delete(fileNameWithPath);

            // return the images data to be stored in the database
            return data;
        }

        public static void ConvertToImage(string path, byte[] image)
        {
            // dump the binary data into a specified file
            File.WriteAllBytes(path, image);
        }
    }
}
