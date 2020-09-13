using StartMeet.DAL;
using System.Linq;

namespace StartMeet.BLL.Users.Queries
{
    public class GetUserIdByUserEmailQuery : IGetUserIdByUserEmailQuery
    {
        private readonly AppIdentityDbContext _context;

        public GetUserIdByUserEmailQuery(AppIdentityDbContext context)
        {
            _context = context;
        }
        public string Get(string email)
        {
            return _context.Users
                .Where(user => user.Email == email)
                .Select(user => user.Id)
                .Single();
        }
    }
}
