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
            View(new Tuple<LoginViewModel, RegisterViewModel>(
                    new LoginViewModel(), new RegisterViewModel()));

        [HttpPost]
        public IActionResult Reg(RegisterViewModel regVM)
        {
            if(!ModelState.IsValid)
                View("Index", new Tuple<LoginViewModel, RegisterViewModel>(
                    new LoginViewModel(), regVM));

            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Log(LoginViewModel logVM){
            if (ModelState.IsValid){

                var user = _userManager.FindByEmailAsync(logVM.Email);

                if (user != null)
                    return RedirectToAction("Reg", "RegLog");

                var res = await _signInManager.PasswordSignInAsync(
                    logVM.Email, logVM.Password, logVM.Remember, false);

                if (res.Succeeded)
                    return RedirectToAction("Index", "Profile");
                else
                    ModelState.AddModelError(string.Empty, "Incorrect login or password.");

            }
            return InvalidLoginRequest(logVM);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut(){
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private IActionResult InvalidLoginRequest(LoginViewModel logVM) =>
            View("Index", new Tuple<LoginViewModel, RegisterViewModel>(logVM, new RegisterViewModel()));

        private IActionResult InvalidRegisterRequest(RegisterViewModel regVM) =>
            View("Index", new Tuple<LoginViewModel, RegisterViewModel>(new LoginViewModel(), regVM));
    }
}
