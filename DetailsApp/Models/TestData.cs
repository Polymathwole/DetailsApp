using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetailsApp.Models
{
    public class TestData
    {
        public static void Seed(AppIdentityDbContext cctx)
        {
            cctx.Database.EnsureCreated();

            if (cctx.Users.Any())
            {
                return;
            }

            User[] users = new User[]
            {
                new User{},
                new User{},
                new User{},
            };

            foreach (User u in users)
            {
                cctx.Users.Add(u);
            }

            cctx.SaveChanges();
        }
    }
}
