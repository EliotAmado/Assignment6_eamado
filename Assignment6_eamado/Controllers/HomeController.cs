using Assignment6_eamado.Models;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieApplicationContext blahContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieApplicationContext someName)
        {
            _logger = logger;
            blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieApplication()
        {
            /*            return View("MovieApplication"); //movie application is a file we created in the views folder
             *            
            */
            return View(); //sends user to confirmation page we created
        }


        [HttpPost]
        public IActionResult MovieApplication(ApplicationResponse ar) //what are we cathing from movieapp.cshtml
        {
            blahContext.Add(ar);
            blahContext.SaveChanges();
            return View("Confirmation", ar);     //Will have all information applicationResponse (all user inputs that page)
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
