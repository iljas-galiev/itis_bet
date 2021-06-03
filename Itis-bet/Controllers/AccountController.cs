using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Services;
using BLL.ViewModels;
using DAL;
using DAL.Models;
using DAL.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BLL.Extensions;
using System.Threading.Tasks;

namespace Itis_bet.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly Database _db;
        private readonly UserManager<User> _user;
        private readonly ProfileService _profile;
        private readonly PassportService _passport;

        public AccountController(Database db, UserManager<User> userManager,
            ProfileService profile, PassportService passport){
            _db = db;
            _user = userManager;
            _profile = profile;
            _passport = passport;
        }

        [HttpGet]
        public IActionResult Index(Tuple<ProfileViewModel, PassportViewModel> model)
        {
            var user = _user.WithProfileAndPassport(User.Identity.Name);

            if (model == null)
                return View(new Tuple<ProfileViewModel, PassportViewModel>(
                        _profile.ConstructView(user), _passport.ConstructView(user)));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(ProfileViewModel newProfile)
        {
            if (ModelState.IsValid)
            {
                var user = _user.WithProfile(User.Identity.Name);

                var someChanges = _profile.Update(user, newProfile);

                if(someChanges)
                    await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return Index(new Tuple<ProfileViewModel, PassportViewModel>(
                newProfile, _passport.ConstructView(_user.WithPassport(User.Identity.Name))));
        }

        [HttpPost]
        public async Task<IActionResult> EditPassport(PassportViewModel newPassport)
        {
            if (ModelState.IsValid)
            {
                var user = _user.WithPassport(User.Identity.Name);

                var someChanges = _passport.Update(user, newPassport);

                if (someChanges)
                    await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return Index(new Tuple<ProfileViewModel, PassportViewModel>(
                _profile.ConstructView(_user.WithProfile(User.Identity.Name)), newPassport));
        }

        [HttpPost]
        public async Task<IActionResult> EditPassword(EditPasswordViewModel newPasswrd)
        {
            if (ModelState.IsValid)
            {
                var user = await _user.FindByNameAsync(User.Identity.Name);

                var passwordsMatch = await _user.CheckPasswordAsync(user, newPasswrd.OldPassword);

                if (passwordsMatch)
                {
                    var passwordHasher = HttpContext.RequestServices
                        .GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;

                    user.PasswordHash = passwordHasher.HashPassword(user, newPasswrd.NewPassword);

                    var res = await _user.UpdateAsync(user);

                    if (res.Succeeded)
                        return View("Index");
                }
            }
            return View("_EditPasswordPartial", new EditPasswordViewModel());
        }

        [HttpGet]
        public IActionResult GetPersonalMenu() =>
            PartialView("_GetPersonalMenu");

        [HttpGet]
        public IActionResult GetBlogPostMenu() =>
            PartialView("_GetBlogPostMenu");

    }
}