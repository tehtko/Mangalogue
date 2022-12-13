﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.IO;
using System.Net;

namespace Mangalogue.Helpers
{
    public class ImageConverter
    {
        public static byte[] ConvertToBinary(IFormFile image, IWebHostEnvironment _webHostEnvironment)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public static void ConvertToImage(string path, byte[] image)
        {
            // dump the binary data into a specified file
            File.WriteAllBytes(path, image);
        }

        public static byte[] DefaultProfileImage()
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadData("https://t3.ftcdn.net/jpg/00/64/67/80/360_F_64678017_zUpiZFjj04cnLri7oADnyMH0XBYyQghG.jpg");
            }
        }
    }
}
