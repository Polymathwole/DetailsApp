using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DetailsApp.Models
{
    public class EFUsersRepo : IUsers
    {
        private UserManager<User> userManager;

        public EFUsersRepo(UserManager<User> um)
        {
            userManager = um;
        }

        public async Task<List<User>> Users() => await userManager.Users.ToListAsync<User>();

        public async Task<IdentityResult> CreateUser(User newUser,string password) => await userManager.CreateAsync(newUser, password);

        public async Task<User> Find(string username)
        {
            User specificUser = await userManager.FindByNameAsync(username);

            return specificUser;
        }
    }
}
