using MediatR;
using ToDiList.Domain.ResultModel;
using ToDoList.Application.DTO.Base_Dto;
using ToDoList.Application.DTO.RequestDto;

namespace ToDoList.Application.Feature.Command.SecurityFeatrue
{
    public class LoginCommand : BaseDto<LoginRequest, LoginCommand>, IRequest<Result<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
