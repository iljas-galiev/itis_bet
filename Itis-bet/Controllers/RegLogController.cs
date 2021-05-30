using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.ViewModels;

namespace Itis_bet.Controllers
{
    public class RegLogController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public RegLogController(UserManager<User> manager, SignInManager<User> signInManager) {
            _signInManager = signInManager;
            _userManager = manager;
        }

        [HttpGet]
        public IActionResult Index() =>
            View();

        [HttpPost]
        public IActionResult Reg(RegisterViewModel regVM)
        {
            if(!ModelState.IsValid)
                View("Index", new Tuple<LoginViewModel, RegisterViewModel>(
                    new LoginViewModel(), regVM));

            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Log(LoginViewModel logVM) =>
            ModelState.IsValid
                ? await _userManager.FindByEmailAsync(logVM.Email) != null
                    ? _signInManager.SignInAsync(
                           await _userManager.FindByEmailAsync(logVM.Email), false)
                                .IsCompletedSuccessfully
                                ? View("Loggined")
                                : throw new ApplicationException()
                : View("NotFound")
            : View("Index", new Tuple<LoginViewModel, RegisterViewModel>(logVM, new RegisterViewModel()));

        [HttpPost]
        public async Task<IActionResult> LogOut() =>
             _signInManager.SignOutAsync()
                    .IsCompletedSuccessfully
                    ? View("Index")
                    : View("Error");
    }
}
