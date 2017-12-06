using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DetailsApp.Models;

namespace DetailsApp.Controllers
{
    public class UserController : Controller
    {
        public ViewResult Index()
        {
            return View(UserEntry.GetUsers());
        }
    }
}
