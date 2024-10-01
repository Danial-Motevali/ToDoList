using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDiList.Domain.Model.Security;
using ToDiList.Domain.Repository;
using ToDoList.Persistense.DATA;
using ToDoList.Persistense.Repository;

namespace ToDoList.Persistense
{
    public static class PersistenseLayerServices
    {
        public static void AddPersistenseServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Add life time of Generic Repository

            services.AddScoped<IRepository<ApplicationUser>, GenericRepository<ApplicationUser>>();

            #endregion

            #region

            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            #endregion

            services.AddDbContext<ApplicationDbContext>(config =>
                config.UseSqlite(configuration.GetConnectionString("sqlite")));
            
        }
    }
}
