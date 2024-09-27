using AutoMapper;
using ToDoList.Application.Contract.AutoMapper;

namespace ToDoList.Application.MapperProfile
{
    public class CustomMappingProfile : Profile
    {
        public CustomMappingProfile(IEnumerable<IHaveCustomMapping> haveCustomMappings)
        {
            foreach (var item in haveCustomMappings)
            {
                item.CreateMappings(this);
            }
        }
    }
}
