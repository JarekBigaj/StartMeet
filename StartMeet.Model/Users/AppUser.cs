using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StartMeet.Model.Users
{
    public class AppUser : IdentityUser
    {
        public string SecondName { get; set; }
    }

    public class RegistrationModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string SecondName { get; set; }

    }

    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
