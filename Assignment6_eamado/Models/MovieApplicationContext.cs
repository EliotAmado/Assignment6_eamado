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
        public DbSet<Category> Categories { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID=1, CategoryName = "Horror"},
                new Category { CategoryID=2, CategoryName = "Action" },
                new Category { CategoryID=3, CategoryName = "Comedy" },
                new Category { CategoryID=4, CategoryName = "Drama" },
                new Category { CategoryID=5, CategoryName = "Fantasy" },
                new Category { CategoryID=6, CategoryName = "Mystery" },
                new Category { CategoryID=7, CategoryName = "Romance" },
                new Category { CategoryID=8, CategoryName = "Thriller" },
                new Category { CategoryID=9, CategoryName = "Sci-Fi" }
                );
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    MovieId = 1,
                    CategoryID = 1,
                    Title = "The Purge",
                    Year = 18,
                    Director = "Gerald McMurray",
                    Rating = "PG-13",
                    Edited = true
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    CategoryID = 1,
                    Title = "Annabell",
                    Year = 14,
                    Director = "David Sandberg",
                    Rating = "R",
                    Edited = true
                },
                new ApplicationResponse
                {
                    MovieId = 3,
                    CategoryID = 1,
                    Title = "DeathDoor",
                    Year = 99,
                    Director = "Devin Hopkins",
                    Rating = "R",
                    Edited = true
                }
                ) ; //cool
        }
    }
}