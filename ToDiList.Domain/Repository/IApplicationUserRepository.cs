using ToDiList.Domain.Model.Security;

namespace ToDiList.Domain.Repository
{
    public interface IApplicationUserRepository 
    {
        Task<bool> IsUnique(string email);
    }
}
