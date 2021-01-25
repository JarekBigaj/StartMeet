﻿
using System.ComponentModel.DataAnnotations;

namespace StartMeet.Model.Users
{
    public class BaseUserModel
    {
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string SecondName { get; set; }
    }
}