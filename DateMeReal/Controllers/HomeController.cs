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

        [HttpGet] // get for the application
        public IActionResult Application()
        {
            ViewBag.Categories = MovieContext.Categories.ToList(); // dynamic var to hold lists of data
            return View(new ApplicationEntry());
        }
        [HttpPost] // post for the application
        public IActionResult Application(ApplicationEntry entry)
        {
            if (ModelState.IsValid) // if valid
            {
                MovieContext.Add(entry);
                MovieContext.SaveChanges();
                return View("confirmation", entry); // return confirmation page
            }
            else // if invalid
            {
                ViewBag.Categories = MovieContext.Categories.ToList(); // greate view bag
                return View(entry); // return the entry
            }
        }
        [HttpGet] // get for the movie list
        public IActionResult MovieList()
        {
            var MovieList = MovieContext.responses
                .Include(x => x.Category) // include the categories
                .ToList(); // put it into list format
            return View(MovieList); // return the movie list
        }


        // Edit and delete
        [HttpGet] // edit get
        public IActionResult Edit (int id)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();
            var entry = MovieContext.responses.Single(x => x.EntryId == id); // lambda find the data where the id's match
            return View("Application", entry);  // pass the view and the correct entry
        }
        [HttpPost] // edit post
        public IActionResult Edit (ApplicationEntry update)
        {
            MovieContext.Update(update);
            MovieContext.SaveChanges(); // save changes

            return RedirectToAction("MovieList"); // return to list, restart the action
        }
        [HttpGet] // get delete
        public IActionResult Delete(int id)
        {
            var entry = MovieContext.responses.Single(x => x.EntryId == id);
            return View(entry);
        }

        [HttpPost] // post delete
        public IActionResult Delete(ApplicationEntry entry)
        {
            MovieContext.responses.Remove(entry);
            MovieContext.SaveChanges();
            return RedirectToAction("MovieList"); // redirect with info to the movie list
        }

    }
}
