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
    [Authorize]
    public class AccountController : Controller
    {
        private readonly Database _db;

        public AccountController(Database db) =>
            _db = db;

        [HttpGet]
        public IActionResult Options() =>
            View();

        [HttpGet]
        public IActionResult Balance() =>
            View();

        [HttpGet]
        public IActionResult Bets() =>
            View();
    }
}