using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StartMeet.BLL.Users.Helpers;
using StartMeet.Model.Users;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace StartMeet.BLL.Users
{
    public class UserRepository : IUserRepository<AppUser>
    {
        private UserManager<AppUser> _userManager;
        private readonly IUserGenerateToken _userTokenGenerator;
        private IPasswordHasher<AppUser> _passwordHasher;

        public UserRepository(UserManager<AppUser> userManager,
            IUserGenerateToken userTokenGenerator,
            IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = userManager;
            _userTokenGenerator = userTokenGenerator;
            _passwordHasher = passwordHasher;
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

        public async Task<Object> Registration(RegistrationModel model)
        {
            AppUser user = new AppUser
            {
                UserName = model.FirstName,
                Email = model.Email,
                SecondName = model.SecondName
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }

        public async Task<Object> Login(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                if (user != null)
                {
                    return _userTokenGenerator.Generate(model.Email);
                }
                else
                    return new BadRequestObjectResult(new { message = "User Email or password is incorrect." });
            }
            else
                return new BadRequestObjectResult(new {message = "User Email is incorrect" });
        }

        public async Task<Object> GetUser(ClaimsPrincipal User)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.UserName,
                user.SecondName,
                user.Email
            };
        }

        public async Task<Object> Edit(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
                return user;
            else
                return new BadRequestObjectResult(new {message = "No User" });
        }

        public async Task<Object> Edit(string id ,EditUserModel model)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                user.Email = model.Email;
                if(!string.IsNullOrEmpty(model.Password))
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                }
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return result;
                else
                    return new BadRequestObjectResult(new { message = "tralala" });
            }
            else 
                return new BadRequestObjectResult(new { message = "tralala2" });
        }

        public string GetLoggedUserId(ClaimsPrincipal user)
        {
            string userId = user.Claims.First(c => c.Type == "UserID").Value;
            return userId;
            
        }
    }
}
