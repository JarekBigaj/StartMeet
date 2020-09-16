
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StartMeet.BLL.Users;
using StartMeet.Model.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StartMeet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private IUserRepository<AppUser> _userRepository;
        public UserProfileController(IUserRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile() 
        {
            return await _userRepository.GetUser(User);
        }
    }
}
