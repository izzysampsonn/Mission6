using DateMeReal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DateMeReal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieEntryContext MovieContext { get; set; } // prep to pass data to database, set context file

        // constructor
        public HomeController(ILogger<HomeController> logger, MovieEntryContext someName)
        {
            _logger = logger;
            MovieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Application()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Application(ApplicationEntry entry)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Add(entry);
                MovieContext.SaveChanges();
                return View("confirmation", entry);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
