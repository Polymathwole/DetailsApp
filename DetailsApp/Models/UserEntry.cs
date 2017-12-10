using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetailsApp.Models
{
    public class UserEntry
    {
        public static IQueryable<User> GetUsers()
        {
            List<User> users = new List<User> {
                new User{},
                new User{},
                new User{},

            };

            return users.AsQueryable<User>();
        }
    }
}
