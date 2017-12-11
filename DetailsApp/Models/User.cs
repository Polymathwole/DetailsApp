using System;
using Microsoft.AspNetCore.Identity;

namespace DetailsApp.Models
{
    public class User:IdentityUser
    {
        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? DoB { get; set; }
    }
}
