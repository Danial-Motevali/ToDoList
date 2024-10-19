using TaskManager.Domain.SystemEntity;

namespace TaskManager.Domain.Contract.Repository
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        ApplicationUser FindTheUserWithUserName(string userName);
    }
}
