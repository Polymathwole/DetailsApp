using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DetailsApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using DetailsApp.Utilities;
using System;
using Microsoft.Extensions.Configuration;

namespace DetailsApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUsers users;
        private SignInManager<User> signInManager;
        private IConfiguration config;

        public AccountController(IUsers use, SignInManager<User> signinMgr, IConfiguration conf)
        {
            users = use;
            signInManager = signinMgr;
            config = conf;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            TempData["message"] = TempData["mess"] ?? "Log in";
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = await users.Find(details.Username);

                    if (user != null)
                    {
                        await signInManager.SignOutAsync();
                        Microsoft.AspNetCore.Identity.SignInResult signInResult = await signInManager.PasswordSignInAsync(user, details.Password, false, false);

                        if (signInResult.Succeeded)
                        {
                            HttpContext.Session.SetJson("User", user);
                            return RedirectToAction("Userprofile");
                        }
                    }
                    ModelState.AddModelError("",
                       "Invalid username or password");
                }

                return View();
            }
            catch (Exception ex)
            {
                string x = config.GetSection("LogPath").Value;

                Logger log = new Logger(x);
                log.WriteError(new string[] { ex.Message,ex.InnerException?.Message,ex.StackTrace });
                return StatusCode(500);
            }
            
        }

        
        public ViewResult Userprofile()
        {
            return View("Userprofile",HttpContext.Session.GetJson<User>("User"));
        }

        public async Task<IActionResult> Logout()
        {
           await signInManager.SignOutAsync();

            ViewBag.Message = "User logged out";
            return View("Login");
        }
    }
}
