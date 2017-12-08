using System.ComponentModel.DataAnnotations;
using System;

namespace DetailsApp.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Specify title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Specify first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Specify last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Specify gender")]
        public string Gender { get; set; }

        [UIHint("Date")]
        [Required(ErrorMessage = "Specify date of birth")]
        public DateTime? DoB { get; set; }

        [StringLength(12,MinimumLength =6,ErrorMessage ="6 <= Username <= 12 characters")]
        [Required(ErrorMessage = "Specify username")]
        public string Username { get; set; }

        [StringLength(16, MinimumLength = 8, ErrorMessage = "8 <= Password <= 16 characters")]
        [Required(ErrorMessage = "Specify password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirm does not match")]
        [Required(ErrorMessage = "Confirm password")]
        public string PasswordConf { get; set; }
    }
}
