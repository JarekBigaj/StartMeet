
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StartMeet.BLL.Configure;
using StartMeet.BLL.Users.Helpers;
using StartMeet.Model.Users;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StartMeet.BLL.Users
{
    public class UserRepository : IUserRepository<AppUser>
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private readonly IUserGenerateToken _userTokenGenerator;

        public UserRepository(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager
            ,IUserGenerateToken userTokenGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userTokenGenerator = userTokenGenerator;
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

        public async Task<AppUser> Login(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(await _userManager.CheckPasswordAsync(user, model.Password))
                return user;

            return null;
        }

        public async Task<Object> GetUser(string userId)
        {
            string _userId = userId;
            var user = await _userManager.FindByIdAsync(_userId);
            return new
            {
                user.UserName,
                user.SecondName
            };
        }
    }
}
