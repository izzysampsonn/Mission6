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

        //seeding
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationEntry>().HasData(
                new ApplicationEntry
                {
                    EntryId = 1,
                    MovieName = "La La Land",
                    Category = "Romance",
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
                    Category = "Action/Adventure",
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
                    Category = "Action/Adventure",
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
