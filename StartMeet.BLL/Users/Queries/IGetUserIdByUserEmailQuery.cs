namespace StartMeet.BLL.Users.Queries
{
    public interface IGetUserIdByUserEmailQuery
    {
        string Get(string email);
    }
}
