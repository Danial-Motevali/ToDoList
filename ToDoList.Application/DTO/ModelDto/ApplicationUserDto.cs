
namespace ToDoList.Application.DTO.ModelDto
{
    public class ApplicationUserDto 
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; private set; }
        public string NormalizeUserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public string NormalizeEmail { get; private set; }
        public bool ConfirmedEmail { get; private set; }
        public string? PhoneNumber { get; private set; }
        public bool? ConfirmedPhoneNumber { get; private set; }
        public bool NeedUpdate { get; private set; }
        public DateTime? LastUpdatedDate { get; private set; }
    }
}
