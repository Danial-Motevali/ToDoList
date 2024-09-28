using AutoMapper;
using ToDiList.Domain.Model.Base;
using ToDoList.Application.Contract.AutoMapper;

namespace ToDoList.Application.DTO.Base_Dto
{
    public class BaseDto<TDto, TEntity, Tkey> : IHaveCustomMapping
        where TDto : class, new()
        where TEntity : class, IBaseModel<Tkey>, new()
    {
        public void CreateCustomMapping(Profile profile)
        {
            var mappingExpression = profile.CreateMap<TDto, TEntity>();

            var dtoType = typeof(TDto);
            var entityType = typeof(TEntity);

            foreach (var property in entityType.GetProperties())
            {
                if (dtoType.GetProperty(property.Name) == null)
                    mappingExpression.ForMember(property.Name, opt => opt.Ignore());
            }

            CreateCustomMapping(mappingExpression.ReverseMap());
        }

        public virtual void CreateCustomMapping(IMappingExpression<TEntity, TDto> mapping)
        {
        }
    }
}
