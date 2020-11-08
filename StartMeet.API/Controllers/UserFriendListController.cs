using Microsoft.AspNetCore.Mvc;
using StartMeet.BLL.Users;
using StartMeet.Model.Users;


namespace StartMeet.API.Controllers
{
    [Route("api/User/[controller]")]
    [ApiController]
    public class UserFriendListController : ControllerBase
    {
        private IUserRepository<AppUser> _userRepository;
        public UserFriendListController(IUserRepository<AppUser> userRepository) => _userRepository = userRepository;

    }
}
