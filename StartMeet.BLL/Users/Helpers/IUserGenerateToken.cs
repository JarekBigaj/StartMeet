
namespace StartMeet.BLL.Users.Helpers
{
    public interface IUserGenerateToken
    {
        UserToken Generate(string email);
    }
}
