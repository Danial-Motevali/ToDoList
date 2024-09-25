using Microsoft.EntityFrameworkCore;
using ToDiList.Domain.Model.Security;
using ToDiList.Domain.Model.System;
using ToDoList.Application.Contract.dbContext;

namespace ToDoList.Persistense.DATA
{
    public class ApplicationDbContext : DbContext, IApplicatioDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<GroupTask> GroupTasks { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<ApplicationTask> Tasks { get; set; }
    }
}
