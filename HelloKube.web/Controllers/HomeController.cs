using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HelloKube.Models;

namespace HelloKube.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["RemoteIpAddress"] = HttpContext.Connection.RemoteIpAddress.ToString();
            ViewData["RequestScheme"] = HttpContext.Request.Scheme;
            ViewData["RequestHost"] = HttpContext.Request.Host;
            ViewData["X-Forwarded-For"] = HttpContext.Request.Headers["X-Forwarded-For"];
            ViewData["X-Forwarded-Proto"] = HttpContext.Request.Headers["X-Forwarded-Proto"];
            ViewData["X-Forwarded-Host"] = HttpContext.Request.Headers["X-Forwarded-Host"];
            

            
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

        public IActionResult Privacy()
        {
            return View();
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
