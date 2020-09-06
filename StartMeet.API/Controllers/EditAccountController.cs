
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StartMeet.BLL.Users;
using StartMeet.Model.Users;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace StartMeet.API.Controllers
{
    [Route("api/User/[controller]")]
    [ApiController]
    public class EditAccountController : ControllerBase
    {
        private IUserRepository<AppUser> _userRepository;
        public EditAccountController(IUserRepository<AppUser> userRepository) => _userRepository = userRepository;

        [HttpPost]
        [Route("Delete")]
        //POST : /api/User/EditAccount/Delete
        public async Task<IActionResult> Delete(string id)
        {
            IdentityResult result = await _userRepository.DeleteAccount(id);

            if (result != null)
                return Ok(result);
            else
                ModelState.AddModelError("", "Nie znaleziono użytkownika");

            return new JsonResult(null);
        }

    }
}
