using Microsoft.AspNetCore.Identity;
using StartMeet.Model.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartMeet.BLL.Users
{
    public interface IUserRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        Task<IdentityResult> Registration(RegistrationModel model);
        Task<IdentityResult> DeleteAccount(string id);
        Task<SignInResult> Login(LoginModel details, string returnUrl);
    }
}
