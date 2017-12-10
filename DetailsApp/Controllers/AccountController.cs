using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DetailsApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using DetailsApp.Utilities;


namespace DetailsApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUsers users;
        private SignInManager<User> signInManager;

        public AccountController(IUsers use, SignInManager<User> signinMgr)
        {
            users = use;
            signInManager = signinMgr;
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
            if (ModelState.IsValid)
            {
                User user = await users.Find(details.Username);

                if (user!=null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult signInResult= await signInManager.PasswordSignInAsync(user, details.Password, false, false);

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
