using AutoMapper;
using ToDoList.Application.Contract.AutoMapper;

namespace ToDoList.Application.MapperProfile
{
    public class CustomMappingProfile : Profile
    {
        public CustomMappingProfile(IEnumerable<IHaveCustomMapping> mappings)
        {
            foreach (var mapping in mappings)
            {
                mapping.CreateCustomMapping(this);
            }
        }
    }
}
