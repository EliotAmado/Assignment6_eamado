using Assignment6_eamado.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
// So this is like a links page using a public class then calling the views folder then the file we want to display to the user in that views folder
namespace Assignment6_eamado.Controllers
{
    public class HomeController : Controller
    {
        private MovieApplicationContext daContext { get; set; }

        //constructor
        public HomeController(MovieApplicationContext someName)
        {
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieApplication() 
        {
            ViewBag.Categories = daContext.Categories.ToList(); //setting up variable to hold list of categories in the seed data 

            return View(); //sends user to confirmation page we created
        }


        [HttpPost]
        public IActionResult MovieApplication(ApplicationResponse ar) //what are we cathing from movieapp.cshtml
        {
            if(ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();
                return View("Confirmation", ar);     //Will have all information applicationResponse (all user inputs that page)
            }
            else //if invalid
            {
                ViewBag.Categories = daContext.Categories.ToList(); 
                return View(); //chance to redo entries
            }

        }

        [HttpGet]
        public IActionResult WaitList ()
        {
            //filtering the data any way we want to in waitlist page from user inputs
            var applications = daContext.responses
                .Include(x=> x.Category) // allows us to show the x.Category.CategoryName in waitlist page
                //.Where(x => x.Edited == true)
                .OrderBy(x => x.Category)
                .ToList(); //setting up a database set, so we can loop through it one at a time
            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int applicationid) //edit page, applicaitonid is from our Waitlist page
        {
            ViewBag.Categories = daContext.Categories.ToList(); //setting up variable to hold list of categories in the seed data 
            
            var application = daContext.responses.Single(x => x.MovieId == applicationid); 

            return View("MovieApplication", application);
        }

        //Updating record
        [HttpPost]
        public IActionResult Edit(ApplicationResponse blah)
        {
            daContext.Update(blah); //update changes
            daContext.SaveChanges(); //save changes

            return RedirectToAction("Waitlist"); //return to waitlists page
        }

        [HttpGet]
        public IActionResult Delete (int applicationid)
        {
            var application = daContext.responses.Single(x => x.MovieId == applicationid);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete (ApplicationResponse ar)
        {
            daContext.responses.Remove(ar);
            daContext.SaveChanges();
            return RedirectToAction("Waitlist");
        }

    }
}
