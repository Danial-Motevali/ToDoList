using ToDoList.Application.MapperProfile;
using System.Reflection;

namespace ToDoList.EndPoint.Extenstion
{
    public static class EndPointLayerServices
    {
        public static void AddEndPointServices(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddSwaggerGen();


            services.AddAutoMapper(config =>
            {
                config.AddCustomMappingProfile();
            }, assemblies);
        }
    }
}
