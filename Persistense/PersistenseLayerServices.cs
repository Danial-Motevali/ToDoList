using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDiList.Domain.Model.Security;
using ToDiList.Domain.Repository;
using ToDiList.Domain.UOW;
using ToDoList.Persistense.DATA;
using ToDoList.Persistense.Repository;
using ToDoList.Persistense.UOW;

namespace ToDoList.Persistense
{
    public static class PersistenseLayerServices
    {
        public static void AddPersistenseServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Add life time of Generic Repository

            services.AddScoped<IRepository<ApplicationUser>, GenericRepository<ApplicationUser>>();

            #endregion
            
            #region Specific Repository

            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            #endregion

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(config =>
                config.UseSqlite(configuration.GetConnectionString("sqlite")));


            
        }
    }
}
