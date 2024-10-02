
using ToDoList.Application.DTO.Base_Dto;
using ToDoList.Application.Feature.Command.SecurityFeatrue;

namespace ToDoList.Application.DTO.ModelDto
{
    public class ApplicationUserDto : BaseDto<ApplicationUserDto, RegisterCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get;  set; }
        public string NormalizeUserName { get;  set; }
        public string PasswordHash { get;  set; }
        public string Email { get; set; }
        public string NormalizeEmail { get; set; }
        public bool ConfirmedEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? ConfirmedPhoneNumber { get; set; }
        public bool NeedUpdate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
