using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.ViewModels;
using Infrastructure.Notifications;

namespace Itis_bet.Controllers
{
    public class RegLogController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly INotificator<bool> _notify;

        public RegLogController(UserManager<User> manager, SignInManager<User> signInManager,
            INotificator<bool> notify) {
            _signInManager = signInManager;
            _notify = notify;
            _userManager = manager;
        }

        [HttpGet]
        public IActionResult Index() =>
            View(new Tuple<LoginViewModel, RegisterViewModel>(
                    new LoginViewModel(), new RegisterViewModel()));

        [HttpPost]
        public async Task<IActionResult> Reg(RegisterViewModel regVM){
            if (ModelState.IsValid){

                var user = await _userManager.FindByEmailAsync(regVM.Email);

                if(user != null)
                {
                    ModelState.AddModelError(string.Empty, "User already exist");
                    return InvalidRegisterRequest(regVM);
                }

                await _userManager.CreateAsync(CreateUser(regVM.Login, regVM.Email), regVM.Password);
                await _notify.AboutRegistrationAsync(RegistrationReason.Succeeded, regVM.Email);

               return await Log(new LoginViewModel { Email = regVM.Email, Password = regVM.Password });

            }
            return InvalidRegisterRequest(regVM);
        }

        [HttpPost]
        public async Task<IActionResult> Log(LoginViewModel logVM){
            if (ModelState.IsValid){

                var user = await _userManager.FindByEmailAsync(logVM.Email);

                if (user == null)
                    return RedirectToAction("Reg", "RegLog");

                var res = await SignIn(user.UserName, logVM.Password, logVM.Remember);

                if (res.Succeeded)
                    return RedirectToAction("Index", "Account");
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

        [HttpGet]
        public IActionResult GetRegPartial() =>
            PartialView("RegPartial", new RegisterViewModel());

        [HttpGet]
        public IActionResult GetLogPartial() =>
            PartialView("LogPartial", new LoginViewModel());

        private IActionResult InvalidLoginRequest(LoginViewModel logVM) =>
            View("Index", new Tuple<LoginViewModel, RegisterViewModel>(logVM, null));

        private IActionResult InvalidRegisterRequest(RegisterViewModel regVM) =>
            View("Index", new Tuple<LoginViewModel, RegisterViewModel>(null, regVM));

        private async Task<Microsoft.AspNetCore.Identity.SignInResult> SignIn(string userName, string password, bool remember) =>
            await _signInManager.PasswordSignInAsync(userName, password, remember, false);

        private User CreateUser(string name, string email) => new User { Email = email, UserName = name };

    }
}
