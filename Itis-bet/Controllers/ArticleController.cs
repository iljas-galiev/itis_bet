using System;
using Itis_bet.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Itis_bet.Controllers
{
    
    
    public class ArticleController : Controller
    {
        private readonly ITISbetContext _db;

        public ArticleController(ITISbetContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public IActionResult Index() =>
            View("Index");
        
        [HttpGet]
        public IActionResult Read(Guid id) =>
            View(_db.Articles.Find(id));
        
        
    }
}