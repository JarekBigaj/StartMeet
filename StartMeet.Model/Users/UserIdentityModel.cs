using System;

namespace StartMeet.Model.Users
{
    public class RegistrationModel : BaseUserModel
    {
        public DateTime BirthDate { get; set; }
        public Gender UserGender { get; set; }

    }

    public class LoginModel : BaseUserModel
    {
    }

    public class EditUserModel : BaseUserModel
    {
    }
}
