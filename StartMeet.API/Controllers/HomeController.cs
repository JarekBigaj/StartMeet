using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StartMeet.BLL.Users;
using StartMeet.BLL.Users.Helpers;
using StartMeet.Model.Users;
using System;
using System.Threading.Tasks;

namespace StartMeet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IUserRepository<AppUser> _userRepository;
        private readonly IUserGenerateToken _userGeneratorToken;
        public HomeController(IUserRepository<AppUser> userRepository , IUserGenerateToken userGeneratorToken)
        {
            _userRepository = userRepository;
            _userGeneratorToken = userGeneratorToken;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/Home/Register
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            IdentityResult result = await _userRepository.Registration(model);
            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        [HttpPost]
        [Route("Login")]
        //POST: /api/Home/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userRepository.Login(model);

            if (user != null)
            {
                return Ok(_userGeneratorToken.Generate(model.Email));
            }
            else
                return BadRequest(new { message = "User Email or password is incorrect." });
        }

    }
}
