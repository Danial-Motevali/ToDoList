using ToDiList.Domain.Model.Security;

namespace ToDoList.Application.Contract.Utilities.IdentityLayer
{
    public interface ITokenHelperUtility
    {
        public string CreateToken(ApplicationUser user);
    }
}
