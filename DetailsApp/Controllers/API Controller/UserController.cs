using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DetailsApp.Models;
using Microsoft.AspNetCore.Identity;

namespace DetailsApp.Controllers.API_Controller
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {   
        private IUsers users;

        public UserController(IUsers use) => users = use;

        [HttpPost]
        public async Task<User> Post([FromBody]CreateUser u)//for persisting a user into the db
        {
            User user = new User
            {
                UserName = u.Username,
                Title = u.Title,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Gender = u.Gender,
                DoB = u.DoB
            };

            IdentityResult result = await users.CreateUser(user, u.Password);

            if (result.Succeeded)
            {
                User usern = await users.Find(u.Username);
                user = new User {
                    Id =usern.Id,
                    Title = usern.Title,
                    FirstName = usern.FirstName,
                    LastName = usern.LastName,
                    Gender = usern.Gender,
                    DoB = usern.DoB,
                    UserName = usern.UserName
                };//to limit the properties sent
            }
            else
                user = null;

            return user;
        }

        [HttpGet("{username}")]
        public async Task<User> Get(string username)//for getting a specific user
        {
            User usern = await users.Find(username);

            User user = new User
            {
                Id = usern.Id,
                Title = usern.Title,
                FirstName = usern.FirstName,
                LastName = usern.LastName,
                Gender = usern.Gender,
                DoB = usern.DoB,
                UserName = usern.UserName
            };//to limit the properties sent

            return user;
        }

        [HttpGet("all")]
        public async Task<List<User>> Get()//for getting all users in the db
        {
            List<User> appusers = await users.Users();
            List<User> modusers = new List<User>();

            foreach (User user in appusers)
               modusers.Add(new User
                {
                    Id = user.Id,
                    Title = user.Title,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    DoB = user.DoB,
                    UserName = user.UserName
               });//to limit the properties sent

            return modusers;
        }

    }
}
