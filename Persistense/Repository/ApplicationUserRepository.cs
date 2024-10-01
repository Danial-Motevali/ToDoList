using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDiList.Domain.Model.Security;
using ToDiList.Domain.Repository;
using ToDoList.Persistense.DATA;

namespace ToDoList.Persistense.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        public ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsUnique(string email)
        {
            return !(await _context.ApplicationUsers.Where(x => x.Email == email).AnyAsync());
        }
    }
}
