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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace Itis_bet.Controllers
{
  
    public class AdminController : Controller
    {
        private readonly Database _db;
        private IWebHostEnvironment _appEnvironment;

        public AdminController(Database db, IWebHostEnvironment appEnvironment)
        {
            _db = db;
            _appEnvironment = appEnvironment;
        }
            

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
            var model = new CreateBlogVM()
            {
                Sports = Sport.All.GetOptionsWithoutAll(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogPost(CreateBlogVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Sports = Sport.All.GetOptionsWithoutAll();
                return View(model);
            }
            if (model.Picture != null)
            {
                // путь к папке Files
                string path = "/images/Articles/" + model.Picture.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await model.Picture.CopyToAsync(fileStream);
                }
                var article = new Articles
                {
                    Description = model.Description,
                    Content = model.Content,
                    Sport = model.Sport,
                    Header = model.Header,
                    Picture = path,
                    PublishedAt = DateTime.Now,
                    UserId = User.GetUserId(),
                };
                _db.Articles.Add(article);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("BlogPosts");
        }
        [HttpGet]
        public IActionResult Comments()
        {
            return View();
        }

    }
}
