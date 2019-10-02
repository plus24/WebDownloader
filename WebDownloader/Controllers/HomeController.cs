using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDownloader.Models;

namespace WebDownloader.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StartDownload(int irid, string url)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (irid == 9662)
                    {
                        Uri uri = new Uri(url);
                        string filename = System.IO.Path.GetFileName(uri.LocalPath);
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = $"/C \"C:\\Program Files (x86)\\Internet Download Manager>idman /d {url} /p C:\\inetpub\\wwwroot\\GalleryServer\\gs\\mediaobjects /f d.mkv /s /q /h /n\"";
                        process.StartInfo = startInfo;
                        process.Start();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return View("Index");
        }
    }
}
