using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DetailsApp.Models
{
    public class EFUsersRepo : IUsers
    {
        private AppDbContext context;
        private User u;

        public EFUsersRepo(AppDbContext ctx)
        {
            context = ctx;
        }

        public async Task<List<User>> Users() => await context.Users.ToListAsync<User>();

        public async Task<IEnumerable<User>> Find(int? id)
        {
            IEnumerable<User> users = (await Users()).Where(u=>u.UserID==id).Select(u=>u);

            if (users.Count()>0)
                return users;
            else
                return null;
        }
    }
}
