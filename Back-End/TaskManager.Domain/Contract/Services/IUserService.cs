namespace TaskManager.Domain.Contract.Services
{
    public interface IUserService
    {
        (bool, string) CreateNewUser(string userName, string password);
        string SignInAUser(string userName, string password);
    }
}
