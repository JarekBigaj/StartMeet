using Microsoft.AspNetCore.Identity;
using System;

namespace StartMeet.Model.Users
{
    public enum Gender
    {
        Male,Female
    }
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string WorkPlace { get; set; }
        public string University { get; set; }
        public string HighSchool { get; set; } 
        public string City { get; set; }
        public string Website { get; set; }
        public string SocialLink { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender UserGender { get; set; }
    }

}
