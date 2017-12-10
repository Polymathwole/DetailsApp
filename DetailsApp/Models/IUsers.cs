using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DetailsApp.Models
{
    public interface IUsers
    {
        Task<List<User>> Users();
        Task<User> Find(string name);
        Task<IdentityResult> CreateUser(User newUser, string password);
    }
}
