using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using DVMN.Services;
using DVMN.Models;

namespace DVMN.Areas.WebManager.Controllers
{
    [Area("WebManager")]
    public class MediaController : Controller 
    {
        public static string DIR_IMAGE = "images";
        public IHostingEnvironment HostingEnvironment { get; set; }

        public MediaController(IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public ActionResult Index()
        {
            var webRoot = HostingEnvironment.WebRootPath;
            var appData = System.IO.Path.Combine(webRoot, DIR_IMAGE);

            var models = Directory.EnumerateFiles(appData).Select(x => new Image
            {
                Pic1 = Url.Content(x),
                ALT = URl
                
            });
            return View();
        }

        public async Task<ActionResult> Save(IEnumerable<IFormFile> files)
        {
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(fileContent.FileName.Trim('"'));
                    var physicalPath = Path.Combine(HostingEnvironment.WebRootPath, DIR_IMAGE, fileName);
                    if (file.Length > 0)
                    {
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        public ActionResult Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(HostingEnvironment.WebRootPath, DIR_IMAGE, fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }
    }
}