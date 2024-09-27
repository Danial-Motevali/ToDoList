using AutoMapper;
using System.Reflection;
using ToDoList.Application.Contract.AutoMapper;

namespace ToDoList.Application.MapperProfile
{
    public static class FindCustomMapperProfile
    {
        //if you dont send the some thing in assemblies input in belove method this one will start and will create that for you
        public static void AddCustomMappingProfile(this IMapperConfigurationExpression config)
        {
            config.AddCustomMappingProfile(AppDomain.CurrentDomain.GetAssemblies().Where(c => c.FullName.StartsWith("ToDoList.Application")).ToArray());
        }

        //the main mehtod. and its will run if you get the assemblies part 
        public static void AddCustomMappingProfile(this IMapperConfigurationExpression config, params Assembly[] assemblies)
        {
            var allTypes = assemblies.SelectMany(a => a.ExportedTypes);

            var list = allTypes.Where(type => type.IsClass && !type.IsAbstract && type.GetInterfaces()
                .Contains(typeof(IHaveCustomMapping)))
                .Select(type => (IHaveCustomMapping)Activator.CreateInstance(type));

            var profile = new CustomMappingProfile(list);

            config.AddProfile(profile);
        }
    }
}
