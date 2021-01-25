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
        public HomeController(IUserRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpPost]
        [Route("Register")]
        //POST : /api/Home/Register
        public async Task<Object> Register(RegistrationModel model)
        {
            return await _userRepository.Registration(model);
        }
        [HttpPost]
        [Route("Login")]
        //POST: /api/Home/Login
        public async Task<Object> Login(LoginModel model)
        {
            return await _userRepository.Login(model);
        }

    }
}
