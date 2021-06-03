using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Models;
using DAL.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BLL.ViewModels.AdminModels;

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
            var tableItems = _db.Articles.Include(a => a.User).Select(a => new BlogsTableItemVM()
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
        public IActionResult GetBlogTableItems(string authorName, Sport sport)
        {
            var posts = _db.Articles.Select(a=>new BlogsTableItemVM()
            {
                Author = a.User.UserName,
                Header = a.Header,
                Published = a.PublishedAt,
                Sport = a.Sport.GetString(),
            });
            if (authorName != null)
            {
                posts = posts.Where(p => p.Author.StartsWith(authorName));
            }
            if(sport != Sport.All)
            {
                posts = posts.Where(p => p.Sport == sport.GetString());
            }
            return PartialView(posts.AsEnumerable());
        }
        [HttpGet]
        public IActionResult Comments()
        {
            return View();
        }

    }
}
