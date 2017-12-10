using System;
using System.ComponentModel.DataAnnotations;

namespace DetailsApp.Models
{
    public class CreateUser
    {
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

        [Required(ErrorMessage = "Specify username")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Username must be between 6 and 12 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Specify password")]
        [StringLength(16, ErrorMessage ="Password must be 16 characters max")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords mismatch")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
