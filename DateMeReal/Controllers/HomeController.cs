using DateMeReal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieEntryContext MovieContext { get; set; } // prep to pass data to database, set context file

        // constructor
        public HomeController(MovieEntryContext someName)
        {
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
            ViewBag.Categories = MovieContext.Categories.ToList(); // dynamic var to hold lists of data
            return View();
        }
        [HttpPost]
        public IActionResult Application(ApplicationEntry entry)
        {
            if (ModelState.IsValid) // if valid
            {
                MovieContext.Add(entry);
                MovieContext.SaveChanges();
                return View("confirmation", entry);
            }
            else // if invalid
            {
                ViewBag.Categories = MovieContext.Categories.ToList();
                return View(entry);
            }
        }
        [HttpGet]
        public IActionResult MovieList()
        {
            var MovieList = MovieContext.responses
                .Include(x => x.Category)
                .ToList();
            return View(MovieList);
        }


        // Edit and delete
        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();
            var entry = MovieContext.responses.Single(x => x.EntryId == id); // lambda find the data where the id's match
            return View("Application", entry);  // pass the view and the correct entry
        }
        [HttpPost]
        public IActionResult Edit (ApplicationEntry update)
        {
            MovieContext.Update(update);
            MovieContext.SaveChanges(); // save changes

            return RedirectToAction("MovieList"); // return to list, restart the action
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entry = MovieContext.responses.Single(x => x.EntryId == id);
            return View(entry);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationEntry entry)
        {
            MovieContext.responses.Remove(entry);
            MovieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

    }
}
