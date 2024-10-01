using AutoMapper;
using ToDiList.Domain.Model.Security;
using ToDoList.Application.Contract.AutoMapper;
using ToDoList.Application.DTO.ModelDto;

namespace ToDoList.Application.MapperProfile.CustomProfile
{
    public class UserDtoToUserMapping : IHaveCustomMapping
    {
        public void CreateCustomMapping(Profile profile)
        {
            profile.CreateMap<ApplicationUserDto, ApplicationUser>()
                .ConvertUsing(src => new ApplicationUser(
                    src.FirstName,
                    src.LastName,
                    src.UserName,
                    src.PasswordHash,
                    src.Email,
                    src.ConfirmedEmail,
                    src.PhoneNumber,
                    src.ConfirmedPhoneNumber,
                    src.NeedUpdate,
                    src.LastUpdatedDate
                ));
        }
    }
}
