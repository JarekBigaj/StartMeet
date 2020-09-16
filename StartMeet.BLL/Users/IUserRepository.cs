using Microsoft.AspNetCore.Identity;
using StartMeet.BLL.Users.Helpers;
using StartMeet.Model.Users;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StartMeet.BLL.Users
{
    public interface IUserRepository<TEntity>
    {
        Task<Object> GetUser(ClaimsPrincipal User);
        Task<IdentityResult> Registration(RegistrationModel model);
        Task<IdentityResult> DeleteAccount(string id);
        Task<AppUser> Login(LoginModel model);
    }
}
