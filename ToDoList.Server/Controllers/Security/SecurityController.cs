using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTO.EndPointsDto;
using ToDoList.Application.Feature.Command;
using ToDoList.EndPoint.Controllers.Base;

namespace ToDoList.EndPoint.Controllers.Security
{
    public class SecurityController : BaseController
    {

        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> Register(RegisterInputDto input)
        {
            try
            {
                return ResultHandler<bool>
                    (
                        await Mediator.Send
                        (
                            _mapper.Map<RegisterCommand>(input)
                        )
                    );
                

            }catch (Exception ex) 
            {
                string message = ex.Message; return Ok(); 
            }
        }

    }
}
