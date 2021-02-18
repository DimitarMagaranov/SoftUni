namespace Git.Services
{
    public interface IUsersService
    {
        void Create(string username, string email, string password);

        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);

        bool IsUserNameAvailable(string username);
    }
}
