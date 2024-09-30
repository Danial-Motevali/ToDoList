using MediatR;
using ToDiList.Domain.ResultModel;
using ToDoList.Application.DTO.Base_Dto;
using ToDoList.Application.DTO.EndPointsDto;

namespace ToDoList.Application.Feature.Command
{
    public class RegisterCommand : BaseDto<RegisterCommand, RegisterInputDto>,  IRequest<Result<bool>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
