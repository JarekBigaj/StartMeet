using StartMeet.Model.Users;
using System;
using System.Threading.Tasks;

namespace StartMeet.BLL.Users
{
    public interface IUserPostsRepository
    {
        Task<Object> GetUserPost(string userId);
    }
}
