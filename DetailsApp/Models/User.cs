using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetailsApp.Models
{
    public class User
    {
        public int? UserID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DoB { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
