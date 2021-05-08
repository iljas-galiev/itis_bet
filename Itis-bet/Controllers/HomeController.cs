﻿using Itis_bet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ITIS_Bet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
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