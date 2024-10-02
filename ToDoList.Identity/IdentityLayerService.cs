using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Contract.Utilities.IdentityLayer;
using ToDoList.Application.Settings;
using ToDoList.Identity.Utilities;

namespace ToDoList.Identity
{
    public static class IdentityLayerService
    {
        public static void AddIdntityLayerService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHashPasswordHelperUtiltiy, HashPasswordHelperUtiltiy>();
            services.AddScoped<ITokenHelperUtility, TokenHelperUtilty>();
        }
    }
}
