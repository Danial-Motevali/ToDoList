namespace TaskManager.Domain.Contract.Services
{
    public interface IUserService
    {
        bool CreateNewUser(string userName, string password);
        string SignInAUser(string userName, string password);
    }
}
