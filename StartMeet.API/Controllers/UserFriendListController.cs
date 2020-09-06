
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StartMeet.BLL.Users;
using StartMeet.Model.Users;
using System;
using System.Collections.Generic;

namespace StartMeet.API.Controllers
{
    [Route("api/User/[controller]")]
    [ApiController]
    public class UserFriendListController : ControllerBase
    {
        private IUserRepository<AppUser> _userRepository;
        public UserFriendListController(IUserRepository<AppUser> userRepository) => _userRepository = userRepository;

        [HttpGet]
        [Route("")]
        //GET: api/User/UserFreindList
        public IActionResult Get()
        {
            IEnumerable<AppUser> appUsers = _userRepository.GetAll();
            return new JsonResult(appUsers);
        }
    }
}
