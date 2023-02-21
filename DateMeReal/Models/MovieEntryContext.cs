using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateMeReal.Models
{
    public class MovieEntryContext : DbContext
    {
        public MovieEntryContext (DbContextOptions<MovieEntryContext> options): base (options) // constructor
        {
            // blank for now
        }
        public DbSet<ApplicationEntry> responses { get; set; } // set connection between database and the program
        public DbSet<Category> Categories { get; set; } // connect Catagory table

        //seeding the data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Romance" },
                new Category { CategoryID = 4, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 5, CategoryName = "Drama" },
                new Category { CategoryID = 6, CategoryName = "Family" },
                new Category { CategoryID = 7, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 8, CategoryName = "Television" },
                new Category { CategoryID = 9, CategoryName = "VHS" }
                );

            // autofill database with top 3 movies
             mb.Entity<ApplicationEntry>().HasData(
                new ApplicationEntry
                {
                    EntryId = 1,
                    MovieName = "La La Land",
                    CategoryID = 3,
                    Year = "2016",
                    Director = "Damien Chazelle",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "A really good movie that makes you think."
                },
                new ApplicationEntry
                {
                    EntryId = 2,
                    MovieName = "Ratatouille",
                    CategoryID = 6,
                    Year = "2007",
                    Director = "Brad Bird",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "Vibes are unmatched."
                },
                new ApplicationEntry
                {
                    EntryId = 3,
                    MovieName = "The Imitation Game",
                    CategoryID = 1,
                    Year = "2014",
                    Director = "Morten Tyldum",
                    Rating = "PG-13",
                    LentTo = "",
                    Edited = false,
                    Notes = ""
                }
            );
        }
    }
}
