using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Data;
using TaskManager.Domain.Contract.Repository;
using TaskManager.Domain.SystemEntity;

namespace TaskManager.Application.Repository
{
    public class TaskRepository : GenericRepository<UserTask>, ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<UserTask>> All(int Id)
        {
            return await _context.UserTasks.Where(x => x.UserId == Id && x.IsDeleted == false).OrderBy(x => x.Created).ToListAsync();
        }

        public async Task<List<UserTask>> AllAndDelete(int Id)
        {
            return await _context.UserTasks.Where(x => x.UserId == Id && x.IsDeleted == true).OrderBy(x => x.Created).ToListAsync();
        }

        public async Task<List<UserTask>> CompletedOnly(int Id)
        {
            return await _context.UserTasks.Where(x => x.UserId == Id && x.IsDeleted == false && x.IsCompleted == true).OrderBy(x => x.Created).ToListAsync();
        }

        public async Task<List<UserTask>> DeletedOnly(int Id)
        {
            return await _context.UserTasks.Where(x => x.UserId == Id && x.IsDeleted == true).OrderBy(x => x.Created).ToListAsync();
        }

        public async Task<List<UserTask>> InProgressOnly(int Id)
        {
            return await _context.UserTasks.Where(x => x.UserId == Id && x.IsDeleted == false && x.IsCompleted == false).OrderBy(x => x.Created).ToListAsync();
        }
    }
}
