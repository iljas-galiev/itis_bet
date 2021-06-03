using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL;

namespace ITIS_Bet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly  Database _dbContext;

        public HomeController(Database context, ILogger<HomeController> logger)
        {
            _dbContext = context;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Personal()
        {
            return View();
        }
        public IActionResult GetPersonalMenu()
        {
            return PartialView("_GetPersonalMenu");
        }
        public IActionResult BlogPost()
        {
            return View();
        }
        public IActionResult GetBlogPostMenu()
        {
            return PartialView("_GetBlogPostMenu");
        }
    }
}
