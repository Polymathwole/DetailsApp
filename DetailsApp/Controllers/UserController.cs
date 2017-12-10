using Microsoft.AspNetCore.Mvc;
using DetailsApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Linq;


namespace DetailsApp.Controllers
{
    public class UserController : Controller
    {
        private IUsers users;

        public UserController(IUsers use)
        {
            users = use;
        }


        [HttpGet]
        public ViewResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(CreateUser cu)
        {
            if (ModelState.IsValid)
            {
                User u = new User
                {
                    UserName = cu.Username,
                    Title = cu.Title,
                    FirstName=cu.FirstName,
                    LastName=cu.LastName,
                    Gender=cu.Gender,
                    DoB=cu.DoB
                };

                IdentityResult result = await users.CreateUser(u, cu.Password);

                if (result.Succeeded)
                {
                    TempData["mess"] = "User successfully created! Log in";
                    return RedirectToRoute("defaultl");
                }
                else
                {
                    foreach (IdentityError err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }

            }

            return View();
        }

        public async Task<ViewResult> GetAll()
        {
            ViewBag.Title = "List Users";
            return View("GetUsers", await users.Users());
        }
    }
}
