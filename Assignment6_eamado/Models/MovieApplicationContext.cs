using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment6_eamado.Models
{
    public class MovieApplicationContext : DbContext //inhereting 
    {
        //Constructor
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options)
        {
            //leave blank for now
        }
        public DbSet<ApplicationResponse> responses { get; set; } //set of data that calls context files and turns it into a set of responses

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    MovieId = 1,
                    Category = "Horror",
                    Title = "The Purge",
                    Year = 18,
                    Director = "Gerald McMurray",
                    Rating = "PG-13",
                    Edited = true
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    Category = "Horror",
                    Title = "Annabell",
                    Year = 14,
                    Director = "David Sandberg",
                    Rating = "R",
                    Edited = true
                },
                new ApplicationResponse
                {
                    MovieId = 3,
                    Category = "Horror",
                    Title = "DeathDoor",
                    Year = 99,
                    Director = "Devin Hopkins",
                    Rating = "R",
                    Edited = true
                }
                ) ;
        }
    }
}
