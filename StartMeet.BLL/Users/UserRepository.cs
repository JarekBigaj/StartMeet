
using Microsoft.AspNetCore.Identity;
using StartMeet.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartMeet.BLL.Users
{
    public class UserRepository : IUserRepository<AppUser>
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public UserRepository(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
            

        public async Task<IdentityResult> DeleteAccount(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                return result;
            }
            else
                return null;
            
        }

        public IEnumerable<AppUser> GetAll()
        {
            return _userManager.Users;
        }

        public async Task<SignInResult> Login(LoginModel details, string returnUrl)
        {
            AppUser user = await _userManager.FindByEmailAsync(details.Email);
            if(user!=null)
            {
                await _signInManager.SignOutAsync();
                SignInResult result = await _signInManager.PasswordSignInAsync(
                    user, details.Password, false, false);

                return result;
            }
            return null;
        }

        public async Task<IdentityResult> Registration(RegistrationModel model)
        {
            AppUser user = new AppUser
            {
                UserName = model.FirstName,
                Email = model.Email,
                SecondName = model.SecondName
            };

            IdentityResult result = await _userManager.CreateAsync(user , model.Password);

            return result;
        }
    }
}
