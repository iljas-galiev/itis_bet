using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Models;
using DAL.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BLL.ViewModels.AdminModels;
using Infrastructure.IdentityExtesions;

namespace Itis_bet.Controllers
{
  
    public class AdminController : Controller
    {
        private readonly Database _db;

        public AdminController(Database db) =>
            _db = db;

        [HttpGet]
        public IActionResult Index() =>
            View();
        [HttpGet]
        public IActionResult BlogPosts()
        {
            var sportOptionsList = Sport.All.GetOptionsWithAll();
            var userEmail = User.GetUserEmail();
            var tableItems = _db.Articles.Include(a => a.User).Where(u=>u.User.Email==userEmail).Select(a => new BlogsTableItemVM()
            {
                Author = a.User.UserName,
                Published = a.PublishedAt,
                Header = a.Header,
                Sport = a.Sport.GetString(),
            });
            var model = new BlogPostsVM()
            {
                Sports = sportOptionsList,
                BlogsTableItems = tableItems,
            };
            return View(model);
        }
        public IActionResult GetBlogTableItems(Sport sport)
        {
            var userEmail = User.GetUserEmail();
            var posts = _db.Articles.Where(a=>a.User.Email==userEmail).Select(a=>new BlogsTableItemVM()
            {
                Author = a.User.UserName,
                Header = a.Header,
                Published = a.PublishedAt,
                Sport = a.Sport.GetString(),
            });
            if(sport != Sport.All)
            {
                posts = posts.Where(p => p.Sport == sport.GetString());
            }
            return PartialView(posts.AsEnumerable());
        }

        [HttpGet]
        public IActionResult CreateBlogPost()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Comments()
        {
            return View();
        }

    }
}
