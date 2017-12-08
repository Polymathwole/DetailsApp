using Microsoft.AspNetCore.Mvc;
using DetailsApp.Models;
using System.Threading.Tasks;
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

        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Signup(User u)
        {
            if (ModelState.IsValid)
            {
                return View("Dashboard");
            }

            return View();
        }

        public async Task<ViewResult> GetAll()
        {
            ViewBag.Title = "List Users";
            return View("GetUsers", await users.Users());
        }
            

        public async Task<ViewResult> GetOne(int? id)
        {
            if (id == null)
            {
                ViewBag.Title = "Get User";
                return View("GetUsers", null);
            }
            else
            {
                ViewBag.Title = "Get User";
                return View("GetUsers", await users.Find(id));
            }
        }
    }
}
