using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Models;
using DAL.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Itis_bet.Controllers
{
    // [Authorize]
    public class AccountController : Controller
    {
        private readonly Database _db;

        public AccountController(Database db) =>
            _db = db;

        [HttpGet]
        public IActionResult Index() =>
            View();

        [HttpGet]
        public IActionResult GetPersonalMenu() =>
            PartialView("_GetPersonalMenu");

        [HttpGet]
        public IActionResult GetBlogPostMenu() =>
            PartialView("_GetBlogPostMenu");

    }
}