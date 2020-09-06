using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StartMeet.BLL.Users;
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
        public HomeController(IUserRepository<AppUser> userRepository) =>
            _userRepository = userRepository;

        [HttpPost]
        [Route("Register")]
        //POST : api/Home/Register
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

    }
}
