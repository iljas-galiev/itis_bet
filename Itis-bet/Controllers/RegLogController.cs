using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Itis_bet.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itis_bet.Controllers
{
    public class RegLogController : Controller
    {
        private readonly UserManager<User> _userManager;

        public RegLogController(UserManager<User> manager) =>
            _userManager = manager;

        [HttpGet]
        public IActionResult Index() =>
            View();

        [HttpPost]
        public IActionResult Reg()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Log() =>


        [HttpPost]
        public IActionResult LogOut()
        {
            return View();
        }
    }
}
