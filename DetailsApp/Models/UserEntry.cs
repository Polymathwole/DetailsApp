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
                new User{UserID=1,Title="Mr",FirstName="Wole",LastName="Dele"},
                new User{UserID=2,Title="Miss",FirstName="Olaide",LastName="Adesopo"},
                new User{UserID=3,Title="Miss",FirstName="Gbemisola",LastName="Odunsi"},

            };

            return users.AsQueryable<User>();
        }
    }
}
