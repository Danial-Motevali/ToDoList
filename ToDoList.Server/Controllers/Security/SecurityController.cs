using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTO.EndPointsDto;
using ToDoList.Application.DTO.RequestDto;
using ToDoList.Application.Feature.Command.SecurityFeatrue;
using ToDoList.EndPoint.Controllers.Base;

namespace ToDoList.EndPoint.Controllers.Security
{
    public class SecurityController : BaseController
    {

        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> Register(RegisterRequest input)
        {
            return ResultHandler
                (
                    await Mediator.Send
                    (
                        _mapper.Map<RegisterCommand>(input)
                    )
                );
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> Login(LoginRequest input)
        {
            return ResultHandler
                (
                    await Mediator.Send
                    (
                        _mapper.Map<LoginCommand>(input)
                    )
                );
        }

    }
}
