using ToDiList.Domain.Model.Security;
using ToDoList.Application.DTO.Base_Dto;
using ToDoList.Application.Feature.Command;

namespace ToDoList.Application.DTO.EndPointsDto
{
    public class RegisterRequest 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
