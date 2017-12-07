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

        public async Task<ViewResult> GetOne() => View(await users.Users());

        public async Task<ViewResult> Index(int? id)
        {
            if (id == null)
                return View(null);
            else
                return View(await users.Find(id));
        }
    }
}
