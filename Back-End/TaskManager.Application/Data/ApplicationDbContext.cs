using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.SystemEntity;

namespace TaskManager.Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

    }
}
