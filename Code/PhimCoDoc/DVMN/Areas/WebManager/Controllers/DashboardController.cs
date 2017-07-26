using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using ImageSharp;

namespace DVMN.Areas.Admin.Controllers
{
    [Area("webmanager")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        [Route("/quan-ly-web/")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        private readonly IFileProvider _fileProvider;
        public DashboardController(IHostingEnvironment env)
        {
            _fileProvider = env.WebRootFileProvider;
        }
        [Route("/resized/{width}/{height}/{*url}")]
        public IActionResult ResizeImage(string url, int width, int height)
        {
            // Preconditions and sanitsation 
            // Check the original image exists
            var originalPath = PathString.FromUriComponent("/" + url);
            var fileInfo = _fileProvider.GetFileInfo(originalPath);
            if (!fileInfo.Exists) { return NotFound(); }

            // Replace the extension on the file (we only resize to jpg currently) 
            var resizedPath = ReplaceExtension($"/resized/{width}/{height}/{url}");

            // Use the IFileProvider to get an IFileInfo
            var resizedInfo = _fileProvider.GetFileInfo(resizedPath);
            // Create the destination folder tree if it doesn't already exist
            Directory.CreateDirectory(Path.GetDirectoryName(resizedInfo.PhysicalPath));

            // resize the image and save it to the output stream
            using (var outputStream = new FileStream(resizedInfo.PhysicalPath, FileMode.CreateNew))
            using (var inputStream = fileInfo.CreateReadStream())
            using (var image = ImageSharp.Image.Load(inputStream))
            {
                image
                    .Resize(width, height)
                    .SaveAsJpeg(outputStream);
            }

            return PhysicalFile(resizedInfo.PhysicalPath, "image/jpg");
        }

        private static string ReplaceExtension(string wwwRelativePath)
        {
            return Path.Combine(
                Path.GetDirectoryName(wwwRelativePath),
                Path.GetFileNameWithoutExtension(wwwRelativePath)) + ".jpg";
        }
    }
}
