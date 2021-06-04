using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;
using DAL;
using Infrastructure.Notifications;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace Itis_bet.Controllers
{
    [AllowAnonymous]
    public class RegLogController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly INotificator<bool> _notify;
        private readonly Database _db;

        public RegLogController(UserManager<User> manager, Database db, SignInManager<User> signInManager,
            INotificator<bool> notify)
        {
            _signInManager = signInManager;
            _notify = notify;
            _userManager = manager;
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return Redirect("/");

            return View(new Tuple<LoginViewModel, RegisterViewModel>(
                new LoginViewModel(), new RegisterViewModel()));
        }

        [HttpPost]
        public async Task<IActionResult> Reg(RegisterViewModel regVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(regVM.Email);

                if (user != null)
                {
                    ModelState.AddModelError(string.Empty, "User already exist");
                    return InvalidRegisterRequest(regVM);
                }

                // Smtp exception catched and return false.
                var validEmail = await _notify.AboutRegistrationAsync(RegistrationReason.Succeeded, regVM.Email);


                if (validEmail)
                {
                    var res = await _userManager.CreateAsync(CreateUser(regVM.Login, regVM.Email, regVM.Phone), regVM.Password);

                    if (res.Succeeded)
                        return await Log(new LoginViewModel { Email = regVM.Email, Password = regVM.Password });                
                }

                ModelState.AddModelError(string.Empty, "Invalid email address");
            }

            return InvalidRegisterRequest(regVM);
        }

        [HttpPost]
        public async Task<IActionResult> Log(LoginViewModel logVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(logVM.Email);

                if (user == null)
                    return RedirectToAction("Reg");

                var res = await SignIn(user.UserName, logVM.Password, logVM.Remember);

                if (res.Succeeded)
                    return RedirectToAction("Index", "Account");
                else
                    ModelState.AddModelError(string.Empty, "Incorrect login or password.");
            }

            return InvalidLoginRequest(logVM);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
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

        private async Task<Microsoft.AspNetCore.Identity.SignInResult> SignIn(string userName, string password,
            bool remember) =>
            await _signInManager.PasswordSignInAsync(userName, password, remember, false);

        private async void SignInVK(User user)
        {
            await _signInManager.SignInAsync(user, true);
        }

        const int VK_CLIENT_ID = 7782410;
        const string VK_CLIENT_SECRET = "8YEm5WQQytMQs5PyaeQl";

        private User CreateUser(string name, string email, string phone) => new User { Email = email, UserName = name, PhoneNumber = phone };


        [HttpGet]
        public IActionResult VkAuth()
        {
            return Redirect(
                $"https://oauth.vk.com/authorize?client_id={VK_CLIENT_ID}&display=page&redirect_uri=https://localhost:5001/reglog/vk&scope=email&response_type=code&v=5.131");
        }

        [HttpGet]
        public async Task<IActionResult> Vk(string code = "")
        {
            if (code == "") return Redirect("/");


            string url =
                $"https://oauth.vk.com/access_token?client_id={VK_CLIENT_ID}&client_secret={VK_CLIENT_SECRET}&redirect_uri=https://localhost:5001/reglog/vk&code={code}";

            try
            {
                var response = GET(url);
                JObject result = JObject.Parse(response);

                var user = _db.Users.SingleOrDefault(u => u.Email.Equals(result.GetValue("email").ToString()));
                if (user == null)
                {
                    return Redirect("/Reglog");
                }

                await _signInManager.SignInAsync(user, true);

                return Redirect("/");
            }
            catch (Exception e)
            {
                return Redirect("/");
            }


        }

        private static string GET(string Url)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }
    }
}
