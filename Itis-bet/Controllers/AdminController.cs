using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using DAL.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Itis_bet.Controllers
{
  
    public class AdminController : Controller
    {
        private readonly ITISbetContext _db;

        public AdminController(ITISbetContext db) =>
            _db = db;

        [HttpGet]
        public IActionResult Index() =>
            View();


    }
}
