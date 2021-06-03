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
        public IActionResult Index()
        {
            return View(_db.Matches.ToList());
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
            var match = _db.Matches
                .SingleOrDefault(a => a.Id.Equals(id));

            if (match == null)
                return RedirectToAction("Index");

            return View("Edit", match);
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

            return View("Edit", _db.Matches
                .Single(a => a.Id.Equals(id)));
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            var match = _db.Matches.FirstOrDefault(r => r.Id.Equals(id));

            if (match == null)
                return RedirectToAction("Index");

            _db.Matches.Remove(match);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
