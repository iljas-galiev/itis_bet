using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Models;
using DAL.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Itis_bet.Controllers
{  
    public class ArticleController : Controller
    {
        private readonly Database _db;

        public ArticleController(Database db) =>
            _db = db;
        
        [HttpGet]
        public IActionResult Index() =>
            View(_db.Articles
                .Include(c => c.Comments)
                .ToList());
        
        [HttpGet]
        public IActionResult Read(Guid id) =>
            View(_db.Articles
                .Where(a => a.Id.Equals(id))
                .Include(a => a.Comments)
                .ThenInclude(u => u.User)
                .ThenInclude(p => p.Profile)
                .Single());
       
        [HttpGet]
        public IActionResult BySport(Sport sport) =>
            View("Index", 
                _db.Articles
                .Where(a => a.Sport.Equals(sport))
                .Include(a => a.Comments)
                .ThenInclude(u => u.User)
                .ToList());


    }
}