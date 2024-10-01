using AutoMapper;
using System.Reflection;
using ToDoList.Application.Contract.AutoMapper;
using ToDoList.Application.MapperProfile;

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


        public static void AddCustomMappingProfile(this IMapperConfigurationExpression config)
        {
            config.AddCustomMappingProfile(AppDomain.CurrentDomain.GetAssemblies().Where(c => c.FullName.StartsWith("ToDoList.Application")).ToArray());
        }

        public static void AddCustomMappingProfile(this IMapperConfigurationExpression config, params Assembly[] assemblies)
        {
            var allTypes = assemblies.SelectMany(a => a.ExportedTypes);

            var list = allTypes.Where(type => type.IsClass && !type.IsAbstract &&
                type.GetInterfaces().Contains(typeof(IHaveCustomMapping)))
                .Select(type => (IHaveCustomMapping)Activator.CreateInstance(type));

            var profile = new CustomMappingProfile(list);

            config.AddProfile(profile);
        }
    }
}
