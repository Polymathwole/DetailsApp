using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace DetailsApp.Models
{
    public class AppIdentityDbContext:IdentityDbContext<User>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
           
        }
    }
}
