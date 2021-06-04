using System;
using System.Linq;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Itis_bet.Controllers
{
    public class MatchAdminController : Controller
    {
        private Database _db;

        public MatchAdminController(Database db) =>
            _db = db;

        // GET
        public IActionResult Index(int page = 1, string sortOrder = "", string search = "")
        {
            var pageSize = 5;

            var matches = from m in _db.Matches select m;

            switch (sortOrder)
            {
                case "title":
                    matches = matches.OrderBy(s => s.Title);
                    break;
                case "title_desc":
                    matches = matches.OrderByDescending(s => s.Title);
                    break;
                default:
                    matches = matches.OrderBy(s => s.Id);
                    break;
            }
            ViewBag.TitleSortParam = sortOrder == "title" ? "title_desc" : "title";

            if (!String.IsNullOrEmpty(search))
            {
                matches = matches.Where(a => a.Title.ToLower().Contains(search.ToLower()));
            }


            ViewData["s"] = search;
            ViewData["sortOrder"] = sortOrder;
            ViewData["page"] = page;
            ViewData["pageSize"] = pageSize;
            ViewData["pageCount"] = Math.Floor((double) (matches.Count() / pageSize))+1;

            matches = matches.Skip((page - 1) * pageSize).Take(pageSize);


            return View(matches.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Edit", (new Matches()));
        }

        [HttpPost]
        public IActionResult Create(Matches model)
        {
            if (ModelState.IsValid)
            {
                _db.Matches.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", (new Matches()));
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var model = _db.Matches
                .SingleOrDefault(a => a.Id.Equals(id));

            if (model == null)
                return RedirectToAction("Index");

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, Matches model)
        {
            if (ModelState.IsValid)
            {
                _db.Matches.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", model);
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            var model = _db.Matches.FirstOrDefault(r => r.Id.Equals(id));

            if (model == null)
                return RedirectToAction("Index");

            _db.Matches.Remove(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
